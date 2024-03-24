using Api_Innovatech.Data;
using Microsoft.AspNetCore.Mvc;
using Api_Innovatech.Model;

namespace Api_Innovatech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private IEmpleado _empleado;

        public EmpleadoController(IEmpleado empleado)
        {
            _empleado = empleado;
        }

        //Lista
        [HttpGet]
        public async Task<IActionResult> ListarEmpleados() {
            return Ok(await _empleado.ListarEmpleados());
        }
       
        //INFO
        [HttpGet("{codigo}")]

        public async Task<IActionResult> MostrarEmpleado(int codigo)
        {
            return Ok(await _empleado.MostarEmpleado(codigo));
        }
        
       // Registrar
       [HttpPost]

       public async Task<IActionResult> RegistrarEmpleado([FromBody] Empleado empleado)
       {
           if (empleado == null)
               return BadRequest();
           if (!ModelState.IsValid)
               return BadRequest(ModelState);
           var registro = await _empleado.RegistrarEmpleado(empleado);
           return Created("Producto registrado...", registro);
       }
        [HttpPut]
        //Actualizar
        public async Task<IActionResult> ActualizarEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var registro = await _empleado.ActualizarEmpleado(empleado);
            return Created("Producto Actualizado...", registro);
        }
        
        //Eliminar
        
        [HttpDelete]

        public async Task<IActionResult> EliminarProducto(String codigo)
        {
            var registro = await _empleado.EliminarEmpleado(codigo);
            return Created("Producto Eliminado ...", registro);
        }

        


    }
}
