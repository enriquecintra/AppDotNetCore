using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos;
using OPPI.WebApi.Extensions;
using OPPI.WebApi.Requests;
using OPPI.WebApi.Services;
using System;
using System.Threading.Tasks;

namespace OPPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticadorController : ControllerBase
    {
        public readonly UsuarioServico _servico;
        public AutenticadorController(UsuarioServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Authenticated()
        {
            var user = this.User.GetUserContext<UsuarioDTO>();
            return Ok(new
            {
                user.Id,
                user.Nome
            });
        }

        [HttpGet]
        [Route("usuario")]
        [Authorize(Roles = "administrador,usuario")]
        public string UserRole() => "Usuário";

        [HttpGet]
        [Route("administrador")]
        [Authorize(Roles = "administrador")]
        public string AdminRole() => "Administrador";


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                var usuario = await _servico.ObterPeloLogin(model.Login);
                if (usuario == null)
                    return NotFound("Usuario não encontrado!");

                if(!Criptografia.CriptografiaMd5.Comparar(usuario.Senha, model.Senha)){
                    return BadRequest("Senha inválida!");
                }

                if (!usuario.Ativo)
                {
                    return BadRequest("Usuário ainda não está ativo no aplicativo! É necessário confirmar sua conta! Caso o link do email de confirmação esteja expirado refaça o primeiro acesso!");
                }


                var token = TokenService.GenerateToken(usuario);
                usuario.Token = token;
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

