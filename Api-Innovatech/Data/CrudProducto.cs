

using Api_Innovatech.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api_Innovatech.Data
{
    public class CrudProducto : IProducto


    {

        private Configuracion _conexion;

        public CrudProducto(Configuracion conexion)
        {
            _conexion = conexion;
        }

        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        //Metodo Listar Productos
        public async Task<IEnumerable<productos>> ListarProducto()
        {
            var bd = Conectar();
            String cad_sql = @"SELECT * FROM productos;";

            return await bd.QueryAsync<productos>(cad_sql, new { });
        }

        //Metodo Mostrar Productos

        public async Task<productos> MostarProducto(int codigo)
        {
            var bd = Conectar();
            String cad_sql = @"select * from productos where id = @cod";
            return await bd.QueryFirstAsync<productos>(cad_sql, new { cod = codigo });
        }

        //Metodo Eliminar Productos

        public async Task<bool> EliminarProducto(string codigo)
        {
            var bd = Conectar();
            String cad_sql = @"delete from productos where id = @cod";

            int n = await bd.ExecuteAsync(cad_sql, new { cod = codigo });

            return n > 0;
        }

        //Metodo Registrar Productos

        public async Task<bool> RegistrarProducto(productos data)
        {
            var bd = Conectar();
            String cad_sql = @"insert into productos values 
                             (@dni,
                              @name,
                              @direc,
                              @tel,
                              @mail,
                              @sueldo,
                              @estado )";

            int n = await bd.ExecuteAsync(cad_sql,
                new
                {
                    dni = data.id,
                    name = data.nombre,
                    direc = data.categoria,
                    tel = data.precio,
                    mail = data.cantidad,
                    sueldo = data.origen,
                    estado = data.descripcion,
                });

            return n > 0;
        }

        public async Task<bool> ActualizarProducto(productos empleado)
        {
            var bd = Conectar();
            String cad_sql = @"update Empleados set 
                            DNI = @dni,
                            Nombre = @name,
                            Direccion = @direc,
                            Telefono = @tel,
                            Email = @mail,
                            Sueldo = @sueldo,
                            Estado_civil = @estado";
            int n = await bd.ExecuteAsync(cad_sql,
                new
                {
                    dni = empleado.id,
                    name = empleado.nombre,
                    direc = empleado.categoria,
                    tel = empleado.precio,
                    mail = empleado.cantidad,
                    sueldo = empleado.origen,
                    estado = empleado.descripcion,

                });
            return n > 0;
        }
    }
}
