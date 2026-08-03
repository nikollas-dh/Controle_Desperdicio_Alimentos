using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly DbDesperdicioAlimentosContext ct;

        public RestauranteController(DbDesperdicioAlimentosContext ct)  
        {
            this.ct = ct;

        }

        [HttpGet]
        public IActionResult GetRestaurantes() 
        {
            try
            {
                var restaurantes = ct.Restaurantes.Select(u => new
                {
                    idRestaurante = u.IdRestaurante,
                    nome = u.Nome,
                    endereco = u.Endereco,
                    telefone = u.Telefone,
                    logotipo = u.Logotipo,


                }).ToList();

                return Ok(restaurantes);

            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Erro interno no servidor");
            }


        }
    }
}
