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
    public class CategoriaController : ControllerBase
    {
        protected readonly CategoriaServico _servico;

        public CategoriaController(CategoriaServico servico)
        {
            _servico = servico;
        }

        [HttpGet("listar/{tipo}/{pagina}/{quantidade}")]
        public IActionResult ListarPorTipo(TipoCategoriaEnum tipo, int pagina, int quantidade)
        {
            var entidade = _servico.ListarPorTipo(tipo, pagina, quantidade);
            if (entidade == null) entidade = Enumerable.Empty<CategoriaDTO>();
            return Ok(entidade);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var entidade = await _servico.ObterPeloIdAsync(id);
            if (entidade == null)
                return BadRequest("Categoria não encontrado!");
            return Ok(entidade);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] CategoriaDTO request)
        {
            try
            {
                return Ok(await _servico.SalvarAsync(request));
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
