using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Controle_de_Tarefas.Controladores
{
    public delegate T ConverterDelegate<T>(IDataReader reader);

    public static class Db
    {
        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";
        public static int Insert(string sql, Dictionary<string, object> parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(sql.AppendSelectIdentity(), connection);

            command.SetParameters(parameters);

            connection.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return id;
        }
        public static void Update(string sql, Dictionary<string, object> parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(sql, connection);

            command.SetParameters(parameters);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
        public static void Delete(string sql, Dictionary<string, object> parameters)
        {
            Update(sql, parameters);
        }
        public static List<T> GetAll<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters = null)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(sql, connection);

            command.SetParameters(parameters);

            connection.Open();

            var list = new List<T>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var obj = convert(reader);
                list.Add(obj);
            }

            connection.Close();
            return list;
        }
        public static T Get<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(sql, connection);

            command.SetParameters(parameters);

            connection.Open();

            T t = default;

            var reader = command.ExecuteReader();

            if (reader.Read())
                t = convert(reader);

            connection.Close();
            return t;
        }

        private static void SetParameters(this SqlCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return;

            foreach (var parameter in parameters)
            {
                if (parameter.Value is string && string.IsNullOrEmpty((string)parameter.Value))
                    parameters[parameter.Key] = null;

                string name = parameter.Key;
                object value = parameter.Value ?? DBNull.Value;

                SqlParameter dbParameter = new SqlParameter(name, value);

                command.Parameters.Add(dbParameter);
            }
        }
        private static string AppendSelectIdentity(this string sql)
        {
            return sql + ";SELECT SCOPE_IDENTITY()";
        }
    }
}