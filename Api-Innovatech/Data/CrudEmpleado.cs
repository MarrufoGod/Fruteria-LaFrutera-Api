

using Api_Innovatech.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api_Innovatech.Data
{
    public class CrudEmpleado : IEmpleado


    {

        private Configuracion _conexion;

        public CrudEmpleado(Configuracion conexion)
        {
            _conexion = conexion;
        }

        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }
        //Metodo Listar

        public async Task<IEnumerable<Empleado>> ListarEmpleados()
        {
            var bd = Conectar();
            String cad_sql = @"sp_Empleados";

            return await bd.QueryAsync<Empleado>(cad_sql, new {});
        }

        public async Task<Empleado> MostarEmpleado(int codigo)
        {

            var bd = Conectar();
            String cad_sql = @"select * from Empleados where DNI = @cod";
            return await bd.QueryFirstAsync<Empleado>(cad_sql, new { cod = codigo });
        }


        public async Task<bool> ActualizarEmpleado(Empleado empleado)
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
                new{
                        dni = empleado.DNI,
                        name = empleado.Nombre,
                        direc = empleado.Direccion,
                        tel = empleado.Telefono,
                        mail = empleado.Email,
                        sueldo = empleado.Sueldo,
                        estado = empleado.Estado_civil,

                    });
                            return n > 0;
        }

        
        public async Task<bool> EliminarEmpleado(string codigo)
        {
            var bd = Conectar();
            String cad_sql = @"delete from Empleados where DNI = @cod";

            int n = await bd.ExecuteAsync(cad_sql, new { cod = codigo });

            return n > 0;
        }

        
        public async Task<bool> RegistrarEmpleado(Empleado empleado)
        {
            var bd = Conectar();
            String cad_sql = @"insert into Empleados values 
                             (@dni,
                              @name,
                              @direc,
                              @tel,
                              @mail,
                              @sueldo,
                              @estado )";

            int n = await bd.ExecuteAsync(cad_sql, 
                new {
                dni = empleado.DNI,
                name = empleado.Nombre,
                direc = empleado.Direccion,
                tel = empleado.Telefono,
                mail = empleado.Email,
                sueldo = empleado.Sueldo,
                estado = empleado.Estado_civil,
            });

            return n > 0;

        }
    }
}
