using Api_Innovatech.Model;

namespace Api_Innovatech.Data
{
    public interface IProducto
    {
        Task<IEnumerable<productos>> ListarProducto();
        Task <productos> MostarProducto(int codigo);
        Task<bool> EliminarProducto(String codigo);
        Task<bool> RegistrarProducto(productos empleado);
        Task<bool> ActualizarProducto(productos empleado);
        
    }
}


