

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



        /*public Task<bool> ActualizarEmpleado(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EliminarEmpleado(string codigo)
        {
            var bd = Conectar();
            String cad_sql = @"delete from Empleados where DNI = @cod";

            int n = await bd.ExecuteAsync(cad_sql, new { cod = codigo });

            return n > 0;
        }

        public Task<bool> RegistrarEmpleado(Empleado empleado)
        {
            throw new NotImplementedException();
        }*/
    }
}
