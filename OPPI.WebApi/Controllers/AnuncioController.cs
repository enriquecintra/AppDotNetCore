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
    public class AnuncioController : ControllerBase
    {
        protected readonly AnuncioServico _servico;

        public AnuncioController(AnuncioServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCompleto()
        {
            var entidade = await _servico.ListarCompleto();
            if (entidade == null)
                return BadRequest("Anuncio não encontrada!");
            return Ok(entidade);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var entidade = await _servico.ObterCompleto(id);
            if (entidade == null)
                return BadRequest("Anuncio não encontrada!");
            return Ok(entidade);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _servico.DeletarAsync(id);
            return Ok();
        }
    }
}
