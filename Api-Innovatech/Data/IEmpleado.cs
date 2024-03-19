using Api_Innovatech.Model;

namespace Api_Innovatech.Data
{
    public interface IEmpleado
    {
        Task<IEnumerable<Empleado>> ListarEmpleados();
         Task <Empleado> MostarEmpleado(int codigo);
       // Task<bool> RegistrarEmpleado(Empleado empleado);
       // Task<bool> ActualizarEmpleado(Empleado empleado);
       // Task<bool> EliminarEmpleado(String codigo);
    }
}


