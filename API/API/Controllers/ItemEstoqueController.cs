using API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemEstoqueController : ControllerBase
    {
      private readonly DbDesperdicioAlimentosContext ct = new DbDesperdicioAlimentosContext();

        public ItemEstoqueController(DbDesperdicioAlimentosContext context) 
        {
            ct = context;
        }

        //[HttpGet("{id:int}")]
        //public ActionResult itemRestaurante([FromRoute]int id) 
        //{
        //    var estoque = ct.ItemEstoques.Where(u=>u.FkIdRestaurante == id)
        //        .Select(i => new
        //        {
        //            id= i.FkIdRestaurante,
        //            item = i.FkIdItemNavigation.Nome,
        //            quantidade = i.Quantidade+ i.FkIdUnidadeNavigation.Nome

        //        }).ToList();
        //        return Ok(estoque);
        //}
    }
}
