

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
            String cad_sql = @"INSERT INTO productos (nombre, categoria, precio, cantidad, origen, descripcion, proveedor_id) 
                      VALUES 
                      (@name, @direc, @tel, @mail, @sueldo, @estado, @proveedorId)";

            int n = await bd.ExecuteAsync(cad_sql,
                new
                {
                    name = data.nombre,
                    direc = data.categoria,
                    tel = data.precio,
                    mail = data.cantidad,
                    sueldo = data.origen,
                    estado = data.descripcion,
                    proveedorId = data.proveedor_id // Asegúrate de que esta propiedad esté presente en tu modelo
                });

            return n > 0;
        }


        public async Task<bool> ActualizarProducto(productos producto)
        {
            var bd = Conectar();
            String cad_sql = @"UPDATE productos SET 
                        nombre = @name,
                        categoria = @direc,
                        precio = @tel,
                        cantidad = @mail,
                        origen = @sueldo,
                        descripcion = @estado
                        WHERE id = @id"; // Asegúrate de añadir esta línea

            int n = await bd.ExecuteAsync(cad_sql,
                new
                {
                    id = producto.id, // Añade el id del producto
                    name = producto.nombre,
                    direc = producto.categoria,
                    tel = producto.precio,
                    mail = producto.cantidad,
                    sueldo = producto.origen,
                    estado = producto.descripcion,
                });

            return n > 0; // Devuelve true si se actualizó al menos un registro
        }

    }
}
