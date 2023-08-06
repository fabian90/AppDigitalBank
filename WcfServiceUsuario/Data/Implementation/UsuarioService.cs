using Dapper;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WcfServiceUsuario.Data.Interface;
using WcfServiceUsuario.Model;
using WcfServiceUsuario.Common.Helper;
using static System.Net.Mime.MediaTypeNames;

namespace WcfServiceUsuario.Data.Implementation
{
    public class UsuarioService : IUsuarioService
    {

        private readonly string connectionString = EncryptionConx.DecryptConnectionString(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //private readonly string connectionString = "Data Source=DESKTOP-776KT05\SQLEXPRESS;Initial Catalog=DigitalBank;Integrated Security=true;Application Name=WcfServiceUsuario;";
        public List<Usuario> ObtenerUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Usuario>("SELECT * FROM Usuario").ToList();
            }
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id); // consultar por Id
                parameters.Add("@Operacion", "Leer"); // Operacion Leer Por Id
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Usuario usuario = connection.QueryFirstOrDefault<Usuario>(
                   crudUsuario,
                   parameters,
                   commandType: System.Data.CommandType.StoredProcedure);


                int rowCount = parameters.Get<int>("@RowCount");

                if (rowCount == -1)
                {
                    Console.WriteLine("Error al eliminar la persona.");
                }
                else
                {
                    Console.WriteLine($"Filas afectadas: {rowCount}");
                }
                return usuario;
            }
        }

        public  int AgregarUsuario(Usuario Usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", Usuario.Nombre);
                parameters.Add("@FechaNacimiento", Usuario.FechaNacimiento);
                parameters.Add("@Sexo", Usuario.Sexo);
                parameters.Add("@Operacion", "Crear"); // Operacion borrar
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute(crudUsuario, parameters, commandType: CommandType.StoredProcedure);

                int rowCount = parameters.Get<int>("@RowCount");

                if (rowCount == -1)
                {
                    Console.WriteLine("Error al eliminar Usuario.");
                }
                else
                {
                    Console.WriteLine($"Filas afectadas: {rowCount}");
                }
                return rowCount;
            }
        }

        public int ActualizarUsuario(Usuario Usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", Usuario.Id);
                parameters.Add("@Nombre", Usuario.Nombre);
                parameters.Add("@FechaNacimiento", Usuario.FechaNacimiento);
                parameters.Add("@Sexo", Usuario.Sexo);
                parameters.Add("@Operacion", "Actualizar"); // Operacion borrar
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute(crudUsuario, parameters, commandType: CommandType.StoredProcedure);

                int rowCount = parameters.Get<int>("@RowCount");

                if (rowCount == -1)
                {
                    Console.WriteLine("Error al eliminar Usuario.");
                }
                else
                {
                    Console.WriteLine($"Filas afectadas: {rowCount}");
                }
                return rowCount;
            }
        }

        public int EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id); // Id de la persona a eliminar
                parameters.Add("@Operacion", "Borrar"); // Operacion borrar
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute(crudUsuario, parameters, commandType: CommandType.StoredProcedure);

                int rowCount = parameters.Get<int>("@RowCount");

                if (rowCount == -1)
                {
                    Console.WriteLine("Error al eliminar la persona.");
                }
                else
                {
                    Console.WriteLine($"Filas afectadas: {rowCount}");
                }
                return rowCount;
            }
        }

        const string crudUsuario = "dbo.sp_GestionarUsuario";


    }
}
