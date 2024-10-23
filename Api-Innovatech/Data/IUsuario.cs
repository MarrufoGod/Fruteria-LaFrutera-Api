using Api_Innovatech.Model;

namespace Api_Innovatech.Data
{
    public interface IUsuario
    {
        Task<IEnumerable<usuario>> ListarUsuario();
        Task<productos> MostarUsuario(int codigo);
        Task<bool> RegistrarUsuario(usuario usuario);
        Task<bool> ActualizarUsuario(usuario usuario);
    }
}
