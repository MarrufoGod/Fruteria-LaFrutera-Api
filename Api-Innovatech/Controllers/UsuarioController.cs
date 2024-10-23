using Api_Innovatech.Data;
using Microsoft.AspNetCore.Mvc;
using Api_Innovatech.Model;
namespace Api_Innovatech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        //Lista
        [HttpGet]
        public async Task<IActionResult> ListarUsuario()
        {
            return Ok(await _usuario.ListarUsuario());
        }
        //INFO
        [HttpGet("{codigo}")]

        public async Task<IActionResult> MostarUsuario(int codigo)
        {
            return Ok(await _usuario.MostarUsuario(codigo));
        }

    }
}
