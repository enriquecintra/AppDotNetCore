using Microsoft.AspNetCore.Mvc;
using OPPI.Dominio.Entidades;
using OPPI.Dominio.Enums;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos;
using OPPI.WebApi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoServico _servico;

        public ProdutoController(ProdutoServico servico)
        {
            _servico = servico;
        }
       
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var entidade = await _servico.ListarTodosAsync();
            return Ok(entidade);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var entidade = await _servico.ObterCompleto(id);
            if (entidade == null)
                return BadRequest("Produto não encontrado!");
            return Ok(entidade);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ProdutoRequest request)
        {
            try
            {
                var dto = new ProdutoDTO()
                {
                    Nome = request.Nome,
                    Resumo = request.Nome,
                    Descricao = request.Descricao,
                    Valor = request.Valor,
                    Desconto = request.Desconto,
                    Destaque = request.Destaque,
                    LojaId = request.LojaId,
                    SegmentoId = request.SegmentoId
                };

                dto = await _servico.SalvarAsync(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Produto entidade)
        {
            try
            {

                Produto produto = null;// = await _servico.ObterPeloIdAsync(id);
                if (produto == null)
                    throw new Exception("Produto não encontrado!");

                //TODO: Mapear alterações
                //await _servico.SalvarAsync(Produto);
                return Ok(new { entidadeId = entidade.Id, id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            //await _servico.DeletarAsync(id);
            return Ok(id);
        }
    }
}
