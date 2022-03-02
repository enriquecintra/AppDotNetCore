using Microsoft.AspNetCore.Mvc;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly PromocaoServico _servico;

        public PromocaoController(PromocaoServico servico)
        {
            _servico = servico;
        }
       
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
           var entidade  = await _servico.ListarTodosAsync();
            if (entidade == null) entidade = Enumerable.Empty<PromocaoDTO>();
            return Ok(entidade);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var entidade = await _servico.ObterPeloIdAsync(id);
            if (entidade == null)
                return BadRequest("Promoção não encontrada!");
            return Ok(entidade);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] PromocaoDTO entidade)
        {
            entidade = await _servico.SalvarAsync(entidade);
            return Ok(entidade.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] PromocaoDTO entidade)
        {
            try
            {

                PromocaoDTO promocao = await _servico.ObterPeloIdAsync(id);
                if (promocao == null)
                {
                    throw new Exception("Promoção não encontrada!");
                }

                //TODO: Mapear alterações
                await _servico.SalvarAsync(promocao);
                return Ok(entidade.Id);
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
