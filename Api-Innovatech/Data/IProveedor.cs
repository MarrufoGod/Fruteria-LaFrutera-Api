using Api_Innovatech.Model;

namespace Api_Innovatech.Data
{
    public interface IProveedor
    {
        Task<IEnumerable<Proveedor>> ListarProveedor();
        Task<Proveedor> MostrarProveedor(int codigo);
        Task<bool> EliminarProveedor(string codigo);
        Task<bool> RegistrarProveedor(Proveedor proveedor);
        Task<bool> ActualizarProveedor(int id, Proveedor proveedor);
    }
}
