using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbDesperdicioAlimentosContext ct = new DbDesperdicioAlimentosContext();

        public UserController(DbDesperdicioAlimentosContext ct) {
            this.ct = ct;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {

            var us = ct.Usuarios.FirstOrDefault(u=>u.Senha== usuario.Senha && u.Email== usuario.Email);
            try
            {
                if (us == null)
                {
                    return StatusCode(401, "Usuário ou senha inválidos!");
                }
                return Ok(us);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
            
        }
        [HttpPost]
        public IActionResult Cadastro([FromBody] Usuario usuario)
        {
            try
            {
                ct.Usuarios.Add(usuario);
                ct.SaveChanges();
                return(Ok(usuario));
            }
            catch (Exception)
            {

                return(StatusCode(500,"Erro interno no servidor"));
            }
        }
}
}
