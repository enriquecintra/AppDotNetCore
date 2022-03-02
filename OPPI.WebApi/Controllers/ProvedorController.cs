using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class ProvedorController : ControllerBase
    {
        protected readonly ProvedorServico _servico;

        public ProvedorController(ProvedorServico servico)
        {
            _servico = servico;
        }

        [HttpGet("listarPorUsuario/{usuarioId}")]
        [Authorize]
        public async Task<IActionResult> ListarPorUsuario(int usuarioId)
        {
            var entidade = await _servico.ListarPorUsuario(usuarioId);
            if (entidade == null) entidade = Enumerable.Empty<ProvedorDTO>();
            return Ok(entidade);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var entidade = await _servico.ObterPeloIdAsync(id);
            if (entidade == null)
                return BadRequest("Provedor não encontrado!");
            return Ok(entidade);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ProvedorRequest request)
        {
            var provedor = await _servico.ObterPeloCNPJ(request.CNPJ);
            if (provedor != null)
                return BadRequest("Provedor já existe!");

            var dto = new ProvedorDTO()
            {
                RazaoSocial = request.RazaoSocial,
                CNPJ = request.CNPJ,
                Telefones = request.Telefones,
                Ativo = request.Ativo,
                Endereco = request.Endereco,
            };

            return Ok(await _servico.SalvarAsync(dto));
        }

        [HttpPost("usuario")]
        public async Task<IActionResult> InserirUsuario([FromBody] UsuarioProvedorRequest request)
        {
            try
            {
                await _servico.InserirUsuario(request.ProvedorId, request.UsuarioId);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ProvedorDTO request)
        {
            try
            {

                var provedor = await _servico.ObterPeloIdAsync(id);
                if (provedor == null)
                    throw new Exception("Provedor não encontrado!");

                provedor.RazaoSocial = request.RazaoSocial;

                await _servico.SalvarAsync(provedor);
                return Ok(request.Id);
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
