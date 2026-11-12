using Library.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private static readonly List<Author> _authors = new List<Author> //List na simulaci dat, později bude DB
        {
            new Author { Id = 1, FirstName = "Karel", LastName="Čapek", BirthYear = 1890},
            new Author { Id = 2, FirstName = "Božena", LastName = "Němcová", BirthYear = 1820  }
        };

        [HttpGet]
        public ActionResult<List<Author>> GetAll() { //ActionResult protože nevíme zda se výsledek povede, může být Ok (200) nebo nějaká chyba, třeba NotFound (404)
            return Ok(_authors); //výsledek se musí zabalit do správného resultu v tomto případě Ok
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetById(int id) {
            foreach (var a in _authors) //Author? author = _authors.FirstOrDefault(a => a.Id == id)
            {
                if (a.Id == id) {
                    return Ok(a); //povedlo se najít, vrátím 200
                }
            }
            return NotFound(); //404
        }
    }
}
