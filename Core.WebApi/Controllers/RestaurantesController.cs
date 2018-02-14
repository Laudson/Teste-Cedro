using Core.Comum.Comum;
using Core.Dominio.Comum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Restaurantes")]
    public class RestaurantesController : Controller
    {
        private readonly CoreDbContext _context;

        public RestaurantesController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurantes
        [HttpGet]
        public IEnumerable<RestauranteDTO> Getrestaurante(string NomeRestaurante)
        {
            if (NomeRestaurante != null)
            {
                return from r in _context.Restaurante
                       where EF.Functions.Like(r.NomeRestaurante, "%" + NomeRestaurante + "%")
                       select r;
            }
            else
            {
                return _context.Restaurante.OrderByDescending(x => x.IdRestaurante);
            }
        }

        // GET: api/Restaurantes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurante([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurante = await _context.Restaurante.SingleOrDefaultAsync(m => m.IdRestaurante == id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return Ok(restaurante);
        }

        // PUT: api/Restaurantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurante([FromRoute] int id, [FromBody] RestauranteDTO restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurante.IdRestaurante)
            {
                return BadRequest();
            }

            _context.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurantes
        [HttpPost]
        public async Task<IActionResult> PostRestaurante([FromBody] RestauranteDTO restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (restaurante.IdRestaurante > 0)
            {
                await PutRestaurante(restaurante.IdRestaurante, restaurante);
            }
            else
            {
                _context.Restaurante.Add(restaurante);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetRestaurante", new { id = restaurante.IdRestaurante }, restaurante);
        }

        // DELETE: api/Restaurantes/5
        [HttpDelete]
        public async Task<IActionResult> DeleteRestaurante(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurante = await _context.Restaurante.SingleOrDefaultAsync(m => m.IdRestaurante == id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurante.Remove(restaurante);

            var prato = _context.Pratos.Where(p => p.IdRestaurante == id).ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var i in prato)
            {
                _context.Pratos.Remove(i);
            }

            await _context.SaveChangesAsync();

            return Ok(restaurante);
        }

        private bool RestauranteExists(int id)
        {
            return _context.Restaurante.Any(e => e.IdRestaurante == id);
        }
    }
}