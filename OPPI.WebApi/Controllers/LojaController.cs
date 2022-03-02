using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPPI.Dominio.Enums;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos;
using OPPI.WebApi.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojaController : ControllerBase
    {
        protected readonly LojaServico _servico;

        public LojaController(LojaServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        [Route("categoria/{categoriaId}/{pagina}/{quantidade}")]
        public async Task<IActionResult> ListarLojaPorCategoria(int categoriaId, int pagina, int quantidade)
        {
            try
            {
                var entidade = await _servico.ListarPorCategoria(categoriaId, pagina, quantidade);
                if (entidade == null) entidade = Enumerable.Empty<LojaDTO>();
                return Ok(entidade);
            }
            catch (Exception)
            {

            }
            return Ok(Enumerable.Empty<LojaDTO>());

        }

        [HttpGet("{pagina}/{quantidade}")]
        public async Task<IActionResult> Listar(int pagina, int quantidade)
        {
            try
            {
                var entidade = await _servico.Listar(pagina, quantidade);
                if (entidade == null) entidade = Enumerable.Empty<LojaDTO>();
                return Ok(entidade);
            }
            catch (Exception)
            {
            }
            return Ok(Enumerable.Empty<LojaDTO>());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var entidade = await _servico.ObterCompleto(id);
            if (entidade == null)
                return BadRequest("Loja não encontrada!");
            return Ok(entidade);
        }


        [HttpGet]
        [Route("localizacao/{latitude}/{longitude}/{raio}")]
        public async Task<IActionResult> ListarPorLocalizacao(decimal latitude, decimal longitude, int raio)
        {
            try
            {
                var entidade = await _servico.ListarPorLocalizacao(latitude, longitude, raio);
                if (entidade == null) entidade = Enumerable.Empty<LojaDTO>();
                return Ok(entidade);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao listar lojas pela locãlizãção" + ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] LojaRequest request)
        {
            try
            {
                var dto = new LojaDTO()
                {
                    CNPJ = request.CNPJ,
                    Nome = request.Nome,
                    Resumo = request.Resumo,
                    Descricao = request.Descricao,
                    TipoFornecedor = (TipoFornecedorEnum)request.TipoFornecedor,
                    Logo = request.Logo,
                    Telefones = request.Telefones.Select(s => new TelefoneDTO()
                    {
                        TipoTelefone = (TipoTelefoneEnum)s.TipoTelefone,
                        DDI = s.DDI,
                        DDD = s.DDD,
                        Numero = s.Numero,
                        Ramal = s.Ramal,

                    }).ToList(),
                    Ativa = request.Ativa,
                    UsuarioId = request.UsuarioId,
                    Endereco = new EnderecoDTO()
                    {
                        TipoEndereco = (TipoEnderecoEnum)request.Endereco.TipoEndereco,
                        CEP = request.Endereco.CEP,
                        Logradouro = request.Endereco.Logradouro,
                        Numero = request.Endereco.Numero,
                        Bairro = request.Endereco.Bairro,
                        Cidade = request.Endereco.Cidade,
                        UF = request.Endereco.UF,
                        Padrao = request.Endereco.Padrao
                    }
                };

                return Ok(await _servico.SalvarAsync(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("plano")]
        public async Task<IActionResult> InserirPlano([FromBody] LojaPlanoPrecoRequest request)
        {
            try
            {
                var dto = new LojaPlanoPrecoDTO()
                {
                    DataInicioVigencia = request.DataInicioVigencia,
                    RenovacaoAutomatica = request.RenovacaoAutomatica,
                    Loja = new LojaDTO()
                    {
                        Id = request.LojaId
                    },
                    PlanoPreco = new PlanoPrecoDTO()
                    {
                        Id = request.PlanoPrecoId
                    },
                };
                await _servico.InserirPlano(dto);
                return Ok(request);
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
    }
}
