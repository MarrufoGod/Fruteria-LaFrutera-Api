using Api_Innovatech.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api_Innovatech.Data
{
    public class CrudProveedor : IProveedor
    {
        private Configuracion _conexion;

        public CrudProveedor(Configuracion conexion)
        {
            _conexion = conexion;
        }

        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        // Método Listar Proveedores
        public async Task<IEnumerable<Proveedor>> ListarProveedor()
        {
            var bd = Conectar();
            String cad_sql = @"SELECT * FROM proveedores;";

            return await bd.QueryAsync<Proveedor>(cad_sql, new { });
        }

        // Método Mostrar Proveedor
        public async Task<Proveedor> MostrarProveedor(int codigo)
        {
            var bd = Conectar();
            String cad_sql = @"SELECT * FROM proveedores WHERE id = @cod;";
            return await bd.QueryFirstAsync<Proveedor>(cad_sql, new { cod = codigo });
        }

        // Método Eliminar Proveedor
        public async Task<bool> EliminarProveedor(string codigo)
        {
            var bd = Conectar();
            String cad_sql = @"DELETE FROM proveedores WHERE id = @cod;";

            int n = await bd.ExecuteAsync(cad_sql, new { cod = codigo });

            return n > 0;
        }

        // Método Registrar Proveedor
        public async Task<bool> RegistrarProveedor(Proveedor data)
        {
            var bd = Conectar();
            String cad_sql = @"INSERT INTO proveedores (nombre, contacto, direccion, telefono, email, pais, descripcion) 
                               VALUES (@name, @contacto, @direccion, @telefono, @email, @pais, @descripcion);";

            int n = await bd.ExecuteAsync(cad_sql,
                new
                {
                    name = data.nombre,
                    contacto = data.contacto,
                    direccion = data.direccion,
                    telefono = data.telefono,
                    email = data.email,
                    pais = data.pais,
                    descripcion = data.descripcion,
                });

            return n > 0;
        }

        // Método Actualizar Proveedor
        public async Task<bool> ActualizarProveedor(Proveedor proveedor)
        {
            var bd = Conectar();
            String cad_sql = @"UPDATE proveedores SET 
                               nombre = @name,
                               contacto = @contacto,
                               direccion = @direccion,
                               telefono = @telefono,
                               email = @email,
                               pais = @pais,
                               descripcion = @descripcion 
                               WHERE id = @id;";

            int n = await bd.ExecuteAsync(cad_sql,
                new
                {
                    id = proveedor.id,
                    name = proveedor.nombre,
                    contacto = proveedor.contacto,
                    direccion = proveedor.direccion,
                    telefono = proveedor.telefono,
                    email = proveedor.email,
                    pais = proveedor.pais,
                    descripcion = proveedor.descripcion,
                });

            return n > 0;
        }
    }
}
