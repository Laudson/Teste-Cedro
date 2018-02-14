using Core.Comum.Comum;
using Core.Dominio.Comum;
using Core.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AutenticacaoController : Controller
    {
        private readonly CoreDbContext _context;

        public AutenticacaoController(CoreDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody]AutenticacaoDTO dto)
        {
            string nome = dto.Usuario.Trim();
            string senha = dto.Senha.Trim();

            var autentica = _context.Autenticacao.Where(a => a.Usuario == dto.Usuario && a.Senha == dto.Senha).ToList();

            if (autentica.Count == 0)
            {
                return Unauthorized();
            }

            return Ok(Autenticacao.geraToken());
        }       
    }
}
