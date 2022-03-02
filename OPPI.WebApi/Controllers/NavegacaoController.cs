using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPPI.Dominio.Entidades;
using OPPI.Dominio.Enums;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos;
using OPPI.WebApi.Extensions;
using OPPI.WebApi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavegacaoController : ControllerBase
    {
        private readonly NavegacaoServico _servico;

        public NavegacaoController(NavegacaoServico servico)
        {
            _servico = servico;
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
        [Authorize]
        public async Task<IActionResult> Inserir([FromBody] NavegacaoDTO navegacao)
        {
            try
            {
                var user = this.User.GetUserContext<UsuarioDTO>();
                var entidade = await _servico.ObterNavegacao(user.Id, navegacao.LojaId);
                if (entidade == null)
                {
                    entidade = new NavegacaoDTO()
                    {
                        UsuarioId = user.Id,
                        LojaId = navegacao.LojaId
                    };
                }
                else
                {
                    entidade.QuantidadeAcesso += 1;
                }

                entidade = await _servico.SalvarAsync(entidade);
                return Ok(entidade);
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

        [HttpGet("listar/{tipo}/{pagina}/{quantidade}")]
        [Authorize]
        public IActionResult ListarNavegacao(NavegacaoEnum tipo, int pagina, int quantidade)
        {
            var user = this.User.GetUserContext<UsuarioDTO>();
            var entidade = _servico.ListarNavegacao(user.Id, tipo, pagina, quantidade);
            if(entidade == null) entidade = Enumerable.Empty<NavegacaoDTO>();
            return Ok(entidade);
        }

    }
}
