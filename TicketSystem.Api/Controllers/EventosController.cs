using Microsoft.AspNetCore.Mvc;
using TicketSystem.Api.Models; // garante que o modelo Evento seja reconhecido

namespace TicketSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private static List<Evento> eventos = new List<Evento>();

        // GET: api/eventos
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            return Ok(eventos);
        }

        // GET: api/eventos/{id}
        [HttpGet("{id}")]
        public ActionResult<Evento> GetById(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();

            return Ok(evento);
        }

        // POST: api/eventos
        [HttpPost]
        public ActionResult<Evento> Post(Evento novoEvento)
        {
            novoEvento.Id = eventos.Count + 1;
            eventos.Add(novoEvento);
            return CreatedAtAction(nameof(GetById), new { id = novoEvento.Id }, novoEvento);
        }

        // PUT: api/eventos/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento eventoAtualizado)
        {
            var evento = eventos.FirstOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();

            evento.Nome = eventoAtualizado.Nome;
            evento.Data = eventoAtualizado.Data;
            evento.Local = eventoAtualizado.Local;

            return NoContent();
        }

        // DELETE: api/eventos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();

            eventos.Remove(evento);
            return NoContent();
        }
    }
}
