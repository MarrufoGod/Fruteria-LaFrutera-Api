using Api_Innovatech.Data;
using Microsoft.AspNetCore.Mvc;
using Api_Innovatech.Model;

namespace Api_Innovatech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private IProducto _producto;

        public ProductoController(IProducto empleado)
        {
            _producto = empleado;
        }

        //Lista
        [HttpGet]
        public async Task<IActionResult> ListarProducto() {
            return Ok(await _producto.ListarProducto());
        }
       
        //INFO
        [HttpGet("{codigo}")]

        public async Task<IActionResult> MostarProducto(int codigo)
        {
            return Ok(await _producto.MostarProducto(codigo));
        }
        
       // Registrar
       [HttpPost]

       public async Task<IActionResult> RegistrarProducto([FromBody] productos nombre)
       {
           if (nombre == null)
               return BadRequest();
           if (!ModelState.IsValid)
               return BadRequest(ModelState);
           var registro = await _producto.RegistrarProducto(nombre);
           return Created("Producto registrado...", registro);
       }
        [HttpPut]
        //Actualizar
        public async Task<IActionResult> ActualizarProducto([FromBody] productos empleado)
        {
            if (empleado == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var registro = await _producto.ActualizarProducto(empleado);
            return Created("Producto Actualizado...", registro);
        }

        //Eliminar

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> EliminarProducto(string codigo)
        {
            var registro = await _producto.EliminarProducto(codigo);
            return Ok(new { mensaje = "Producto Eliminado ...", registro });
        }





    }
}
