using Api_Innovatech.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api_Innovatech.Data
{
    public class CrudUsuario : IUsuario
    {
        private Configuracion _conexion;

        public CrudUsuario(Configuracion conexion)
        {
            _conexion = conexion;
        }
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        public Task<bool> ActualizarUsuario(usuario usuario)
        {
            throw new NotImplementedException();
        }

        //Metodo Listar
        public async Task<IEnumerable<usuario>> ListarUsuario()
        {
            var bd = Conectar();
            String cad_sql = @"SELECT * FROM usuario;";

            return await bd.QueryAsync<usuario>(cad_sql, new { });
        }

        public async Task<usuario> MostarUsuario(int codigo)
        {
            var bd = Conectar();
            String cad_sql = @"select * from usuario where id = @cod";
            return await bd.QueryFirstAsync<usuario>(cad_sql, new { cod = codigo });
        }

        public async Task<bool> RegistrarUsuario(usuario usuario)
        {
            var bd = Conectar();  // Conexión a la base de datos

            // Llamar al procedimiento almacenado 'registrar_usuario'
            String cad_sql = "CALL registrar_usuario(@name, @pass)";

            // Ejecutar el comando SQL con los parámetros correspondientes
            int n = await bd.ExecuteAsync(cad_sql, new
            {
                name = usuario.nombre,  // Pasamos el nombre del usuario
                pass = usuario.pass     // Pasamos la contraseña (el SP se encargará de hashearla)
            });

            return n > 0;  // Devuelve true si la inserción fue exitosa
        }

        Task<productos> IUsuario.MostarUsuario(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}
