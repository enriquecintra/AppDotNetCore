using Microsoft.AspNetCore.Mvc;
using OPPI.Dominio.Enums;
using OPPI.Servico.DTO;
using OPPI.Servico.Email;
using OPPI.Servico.Servicos;
using OPPI.WebApi.Extensions;
using OPPI.WebApi.Interfaces;
using OPPI.WebApi.Models;
using OPPI.WebApi.Requests;
using OPPI.WebApi.Responses;
using OPPI.WebApi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OPPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        protected readonly UsuarioServico _servico;
        private readonly IEmailServico _emailServico;

        public UsuarioController(UsuarioServico servico, IEmailServico emailServico)
        {
            _servico = servico;
            _emailServico = emailServico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var entidade = await _servico.ListarTodosAsync();
            if (entidade == null) entidade = Enumerable.Empty<UsuarioDTO>();
            return Ok(entidade);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var entidade = await _servico.ObterPeloIdAsync(id);
            if (entidade == null)
                return BadRequest("Usuario não encontrado!");
            return Ok(entidade);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] UsuarioRequest request)
        {
            if(await _servico.Existe(0, request.Email, request.CPF))
                return BadRequest("Usuário já existe!");


            var entidade = new UsuarioDTO
            {
                Nome = request.Nome,
                Email = request.Email,
                Documentos = new List<DocumentoDTO>()
                {
                    new DocumentoDTO()
                    {
                        TipoDocumento = TipoDocumentoEnum.CPF,
                        Numero = request.CPF
                    }
                },
                Telefones = new List<TelefoneDTO>()
                {
                    request.Telefone
                },
                Enderecos = new List<EnderecoDTO>()
                {
                    request.Endereco
                }
            };

            entidade.Role = RoleEnum.Usuario.ToString();
            return Ok(await _servico.SalvarAsync(entidade));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UsuarioRequest request)
        {
            try
            {

                var usuario = await _servico.ObterPeloIdAsync(id);
                if (usuario == null)
                    throw new Exception("Usuario não encontrado!");

                //TODO: Mapear alterações
                await _servico.SalvarAsync(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _servico.DeletarAsync(id);
            return Ok();
        }

        [HttpPost("alterarsenha")]
        public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenhaRequest request)
        {
            try
            {
                var usuarioToken = TokenService.ValidateJwtToken(request.Token, false).GetUserContext<UsuarioDTO>();
                var usuario = await _servico.ObterPeloIdAsync(usuarioToken.Id);
                if (usuario == null)
                    throw new Exception("Usuario não encontrado!");

                usuario.Senha = Criptografia.CriptografiaMd5.Criptografar(request.Senha);
                await _servico.SalvarAsync(usuario);
                return Ok(new ResponseBase() { Mensagem = "Senha atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("primeiroacesso/{login}")]
        public async Task<IActionResult> PrimeiroAcesso(string login, [FromBody] PrimeiroAcessoRequest request)
        {
            try
            {
                var usuario = await _servico.ObterPeloLogin(login);
                if (usuario == null)
                    throw new Exception("Usuario não encontrado!");

                if (usuario.Ativo)
                    throw new Exception("Usuario já está ativo!");

                if (await _servico.Existe(usuario.Id, request.Email, request.CPF))
                    throw new Exception("Já existe outro usuário com esse dado!");

                usuario = await _servico.ObterCompleto(usuario.Id);

                usuario.Email = request.Email;
                var documentoCPF = usuario.Documentos?.FirstOrDefault(d => d.TipoDocumento == TipoDocumentoEnum.CPF);
                if (documentoCPF == null)
                {
                    if (usuario.Documentos == null) usuario.Documentos = new List<DocumentoDTO>();
                    usuario.Documentos.Add(new DocumentoDTO()
                    {
                        TipoDocumento = TipoDocumentoEnum.CPF,
                        Numero = request.CPF
                    });
                }
                else
                {
                    documentoCPF.TipoDocumento = TipoDocumentoEnum.CPF;
                    documentoCPF.Numero = request.CPF;
                }
                usuario.DataAceiteTermos = DateTime.Now;
                usuario.DataAceitePolitica = DateTime.Now;
                usuario.Senha = Criptografia.CriptografiaMd5.Criptografar(request.Senha);
                await _servico.SalvarAsync(usuario);


                usuario.CodigoConfirmacao = new Random().Next(100000, 999999);
                var token = TokenService.GenerateToken(usuario);
                var model = new PrimeiroAcessoModel()
                {
                    Nome = usuario.Nome,
                    Codigo = usuario.CodigoConfirmacao.ToString()
                };


                EnviarEmail(model, usuario, "Primeiro Acesso", "PrimeiroAcesso.cshtml");

                return Ok(new TokenResponse(){ Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("reenviarcodigo")]
        public IActionResult ReenviarCodigo([FromBody] ConfirmacaoRequest request)
        {
            var usuario = TokenService.ValidateJwtToken(request.Token, false).GetUserContext<UsuarioDTO>();
            usuario.CodigoConfirmacao = new Random().Next(100000, 999999);
            request.Token = TokenService.GenerateToken(usuario);
            var model = new ConfirmacaoModel()
            {
                Nome = usuario.Nome,
                Codigo = usuario.CodigoConfirmacao.ToString()
            };

            EnviarEmail(model, usuario, "Confirmação OPPI", "Confirmacao.cshtml");

            return Ok(new TokenResponse() { Token = request.Token });
        }

        [HttpPost("confirmar")]
        public async Task<IActionResult> Confirmar([FromBody] ConfirmacaoRequest request)
        {
            try
            {
                var usuario = TokenService.ValidateJwtToken(request.Token).GetUserContext<UsuarioDTO>();
                var entidade = await _servico.ObterPeloIdAsync(usuario.Id);
                if (entidade == null)
                    throw new Exception("Usuario não encontrado!");

                if(usuario.CodigoConfirmacao != request.Codigo)
                    throw new Exception("Código Inválido!");

                entidade.Ativo = true;
                await _servico.SalvarAsync(entidade);
                return Ok(new TokenResponse() { Token = request.Token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("esqueciminhasenha/{login}")]
        public async Task<IActionResult> EsqueciMinhaSenha(string login)
        {
            try
            {
                var usuario = await _servico.ObterPeloLogin(login);
                if (usuario == null)
                    throw new Exception("Usuario não encontrado!");

                usuario.CodigoConfirmacao = new Random().Next(100000, 999999);
                var token = TokenService.GenerateToken(usuario);
                var model = new EsqueciMinhaSenhaModel()
                {
                    Nome = usuario.Nome,
                    Codigo = usuario.CodigoConfirmacao.ToString()
                };
                EnviarEmail(model, usuario, "Esqueci Minha Senha", "Confirmacao.cshtml");

                return Ok(new TokenResponse() { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        private void EnviarEmail(ITemplateEmail model, UsuarioDTO usuario, string assunto, string nomeArquivo)
        {
            new Thread(async () =>
            {
                var email = model.ToEmail(Path.Combine(Directory.GetCurrentDirectory(), "Pages", nomeArquivo));
                await _emailServico.EnviarEmailAsync(usuario.Email, assunto, email);
            }).Start();
        }
    }
}
