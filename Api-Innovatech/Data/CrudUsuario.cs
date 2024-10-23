using Api_Innovatech.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api_Innovatech.Data
{
    public class CrudUsuario : IUsuario
    {
        public Task<bool> ActualizarUsuario(usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<usuario>> ListarUsuario()
        {
            throw new NotImplementedException();
        }

        public Task<productos> MostarUsuario(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegistrarUsuario(usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
