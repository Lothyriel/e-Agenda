using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Controle_de_Tarefas.Controladores
{
    public delegate T ConverterDelegate<T>(DbDataReader reader);

    public static class Db
    {
        private static string bancoSelecionado = ConfigurationManager.AppSettings["bancoDeDados"];
        private static string connectionString = ConfigurationManager.ConnectionStrings[bancoSelecionado].ConnectionString;

        public static int Insert(string sql, Dictionary<string, object> parameters)
        {
            DbConnection connection = dbConnection();
            DbCommand command = dbComand(sql.AppendSelectIdentity(), connection);

            command.SetParameters(parameters);

            connection.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return id;
        }
        public static void Update(string sql, Dictionary<string, object> parameters)
        {
            DbConnection connection = dbConnection();
            DbCommand command = dbComand(sql, connection);

            command.SetParameters(parameters);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
        public static void Delete(string sql, Dictionary<string, object> parameters = null)
        {
            Update(sql, parameters);
        }
        public static List<T> GetAll<T>(string sql, ConverterDelegate<T> convert)
        {
            DbConnection connection = dbConnection();
            DbCommand command = dbComand(sql, connection);

            connection.Open();

            var list = new List<T>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var obj = convert(reader);
                list.Add(obj);
            }
            reader.Close();
            connection.Close();
            return list;
        }
        public static T Get<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters)
        {
            DbConnection connection = dbConnection();
            DbCommand command = dbComand(sql, connection);

            command.SetParameters(parameters);

            connection.Open();

            T t = default;

            var reader = command.ExecuteReader();

            if (reader.Read())
                t = convert(reader);

            reader.Close();
            connection.Close();
            return t;
        }
        private static void SetParameters(this DbCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return;

            foreach (var parameter in parameters)
            {
                if (parameter.Value is string && string.IsNullOrEmpty((string)parameter.Value))
                    parameters[parameter.Key] = null;

                string name = parameter.Key;
                object value = parameter.Value ?? DBNull.Value;
                DbParameter _dbParameter = dbParameter(name, value);

                command.Parameters.Add(_dbParameter);
            }
        }
        private static DbConnection dbConnection()
        {
            if (ConfigurationManager.AppSettings["bancoDeDados"] == "SQLServer")
                return new SqlConnection(connectionString);
            if (ConfigurationManager.AppSettings["bancoDeDados"] == "SQLite")
                return new SQLiteConnection(connectionString);
            return null;
        }
        private static DbCommand dbComand(string sql, DbConnection connection)
        {
            if (ConfigurationManager.AppSettings["bancoDeDados"] == "SQLServer")
                return new SqlCommand(sql, (SqlConnection)connection);
            if (ConfigurationManager.AppSettings["bancoDeDados"] == "SQLite")
                return new SQLiteCommand(sql, (SQLiteConnection)connection);
            return null;
        }
        private static DbParameter dbParameter(string name, object value)
        {
            if (ConfigurationManager.AppSettings["bancoDeDados"] == "SQLServer")
                return new SqlParameter(name, value);
            if (ConfigurationManager.AppSettings["bancoDeDados"] == "SQLite")
                return new SQLiteParameter(name, value);
            return null;
        }
        private static string AppendSelectIdentity(this string sql)
        {
            if (ConfigurationManager.AppSettings["bancoDeDados"] == "SQLServer")
                return sql + ";SELECT SCOPE_IDENTITY()";
            if (ConfigurationManager.AppSettings["bancoDeDados"] == "SQLite")
                return sql + ";SELECT last_insert_rowid()";
            else return sql;
        }
    }
}