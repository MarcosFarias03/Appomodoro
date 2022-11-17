using ApiAppomodoro.Models;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ApiAppomodoro.Handlers
{
    public static class TareasHandler
    {
        public const string connectionString = "Server=DESKTOP-3QSS3IP;Database=Appomodoro;Trusted_Connection=True";

        public static bool InsertarTarea(Tareas tareas)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryInsert = "INSERT INTO Tareas (Tarea) VALUES (@tareaParameter)";
                    SqlParameter @tareaParameter = new SqlParameter("tareaParameter", System.Data.SqlDbType.VarChar) { Value = tareas.Tarea};

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(tareaParameter);

                        int queryRow = sqlCommand.ExecuteNonQuery();
                        if (queryRow > 0)
                        {
                            resultado = true;
                        }
                    }
                    sqlConnection.Close();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return resultado;
            }
        }


        public static bool EliminarTarea(int Id)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryDelete = "DELETE FROM Tareas WHERE Id = @idParameter";
                    SqlParameter @idParameter = new SqlParameter("idParameter", System.Data.SqlDbType.VarChar) { Value = Id };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(idParameter);

                        int queryRow = sqlCommand.ExecuteNonQuery();
                        if (queryRow > 0)
                        {
                            resultado = true;
                        }
                    }
                    sqlConnection.Close();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return resultado;
            }
        }


        public static bool ModificarTarea(Tareas tareas)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryDelete = "UPDATE Tareas SET Tarea = @tareaParameter WHERE Id = @idParameter";
                    SqlParameter @idParameter = new SqlParameter("idParameter", System.Data.SqlDbType.BigInt) { Value = tareas.Id };
                    SqlParameter @tareaParameter = new SqlParameter("tareaParameter", System.Data.SqlDbType.VarChar) { Value = tareas.Tarea };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(idParameter);
                        sqlCommand.Parameters.Add(tareaParameter);

                        int queryRow = sqlCommand.ExecuteNonQuery();
                        if (queryRow > 0)
                        {
                            resultado = true;
                        }
                    }
                    sqlConnection.Close();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return resultado;
            }
        }

        public static List<Tareas> MostrarTareas(string tarea)
        {
            List<Tareas> listTask = new List<Tareas>();
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string querySelect = "SELECT Tarea FROM Tareas WHERE Tarea LIKE '@tarea%'";
                    SqlParameter sqlParameter = new SqlParameter("Tarea", System.Data.SqlDbType.VarChar) { Value = tarea };

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlCommand.ExecuteNonQuery();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Tareas tareas = new Tareas();
                                    tareas.Id = Convert.ToInt32(dataReader["Id"]);
                                    tareas.Tarea = dataReader["Tarea"].ToString();

                                    listTask.Add(tareas);
                                }
                            }
                        }
                    }
                    sqlConnection.Close();
                }
                return listTask;
            }
            catch (Exception)
            {
                return listTask;
            }
        }

    }
}
