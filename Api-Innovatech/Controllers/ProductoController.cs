using Api_Innovatech.Data;
using Microsoft.AspNetCore.Mvc;
using Api_Innovatech.Model;

namespace Api_Innovatech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private IProducto _empleado;

        public ProductoController(IProducto empleado)
        {
            _empleado = empleado;
        }

        //Lista
        [HttpGet]
        public async Task<IActionResult> ListarProducto() {
            return Ok(await _empleado.ListarProducto());
        }
       
        //INFO
        [HttpGet("{codigo}")]

        public async Task<IActionResult> MostarProducto(int codigo)
        {
            return Ok(await _empleado.MostarProducto(codigo));
        }
        
       // Registrar
       [HttpPost]

       public async Task<IActionResult> RegistrarProducto([FromBody] productos empleado)
       {
           if (empleado == null)
               return BadRequest();
           if (!ModelState.IsValid)
               return BadRequest(ModelState);
           var registro = await _empleado.RegistrarProducto(empleado);
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
            var registro = await _empleado.ActualizarProducto(empleado);
            return Created("Producto Actualizado...", registro);
        }
        
        //Eliminar
        
        [HttpDelete]

        public async Task<IActionResult> EliminarProducto(String codigo)
        {
            var registro = await _empleado.EliminarProducto(codigo);
            return Created("Producto Eliminado ...", registro);
        }

        


    }
}
