using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace Controle_de_Tarefas.Controladores
{
    public delegate T ConverterDelegate<T>(DbDataReader reader);

    public static class Db
    {
        private static readonly string bancoSelecionado;
        private static readonly DbProviderFactory factory;
        private static readonly string connectionString;

        static Db()
        {
            var table = DbProviderFactories.GetFactoryClasses();

            bancoSelecionado = ConfigurationManager.AppSettings["bancoDeDados"];
            connectionString = ConfigurationManager.ConnectionStrings[bancoSelecionado].ConnectionString;
            string nomeProvedor = ConfigurationManager.ConnectionStrings[bancoSelecionado].ProviderName;
            factory = DbProviderFactories.GetFactory(nomeProvedor);
        }
        public static int Insert(string sql, Dictionary<string, object> parameters)
        {
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            DbCommand command = connection.CreateCommand();
            command.CommandText = sql.getIdInserido();
            command.Connection = connection;

            command.SetParameters(parameters);

            connection.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return id;
        }
        public static void Update(string sql, Dictionary<string, object> parameters)
        {
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            DbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Connection = connection;

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
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            DbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Connection = connection;

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
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            DbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Connection = connection;

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
                DbParameter dbParameter = command.CreateParameter();
                dbParameter.ParameterName = name;
                dbParameter.Value = value;

                command.Parameters.Add(dbParameter);
            }
        }
        private static string getIdInserido(this string sql)
        {
            switch (bancoSelecionado)
            {
                case "SQLServer": return sql + ";SELECT SCOPE_IDENTITY()";
                case "SQLite": return sql + ";SELECT LAST_INSERT_ROWID()";
                default: throw new ArgumentException(message: "Invalid providerName");
            }
        }
    }
}