using Api_Innovatech.Data;
using Microsoft.AspNetCore.Mvc;
using Api_Innovatech.Model;

namespace Api_Innovatech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : Controller
    {
        private IProveedor _proveedor;

        public ProveedorController(IProveedor proveedor)
        {
            _proveedor = proveedor;
        }

        // Lista
        [HttpGet]
        public async Task<IActionResult> ListarProveedor()
        {
            return Ok(await _proveedor.ListarProveedor());
        }

        // INFO
        [HttpGet("{codigo}")]
        public async Task<IActionResult> MostrarProveedor(int codigo)
        {
            return Ok(await _proveedor.MostrarProveedor(codigo));
        }

        // Registrar
        [HttpPost]
        public async Task<IActionResult> RegistrarProveedor([FromBody] Proveedor proveedor)
        {
            if (proveedor == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState + "Error de formato");
            var registro = await _proveedor.RegistrarProveedor(proveedor);
            return Created("Proveedor registrado...", registro);
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProveedor(int id,[FromBody]  Proveedor proveedor)
        {
            if (proveedor == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var registro = await _proveedor.ActualizarProveedor(id, proveedor);
            return Created("Proveedor actualizado...", registro);
        }

        // Eliminar
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> EliminarProveedor(string codigo)
        {
            var registro = await _proveedor.EliminarProveedor(codigo);
            return Created("Proveedor eliminado...", registro);
        }
    }
}
