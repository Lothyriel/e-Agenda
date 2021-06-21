using Controle_de_Tarefas.Dominio;
using Controle_de_Tarefas.Telas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Controle_de_Tarefas.Controladores
{
    abstract public class Controlador<T> where T : Entidade
    {
        protected abstract string nomeTabela { get; }
        public List<T> Registros => registros();
        public void inserir(T registro)
        {
            string enderecoDB = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection(enderecoDB);
            conexaoComBanco.Open();
            SqlCommand comandoSql = new SqlCommand();
            comandoSql.Connection = conexaoComBanco;

            var props = propriedades();
            var nomesProps = nomesPropriedades(props);

            string sqlcommand =
                $@"INSERT INTO {nomeTabela}
                    (
                    {String.Join(",\n", montarLinhas("[", "]", nomesProps)).TrimEnd(new char[] { ',', '\n' })}
                    )
                    VALUES
                    (
                    {String.Join(",\n", montarLinhas("@", "", nomesProps)).TrimEnd(new char[] { ',', '\n' })}
                    );
                 SELECT SCOPE_IDENTITY();";

            comandoSql.CommandText = sqlcommand;

            for (int i = 0; i < props.Count; i++)
                comandoSql.Parameters.AddWithValue(nomesProps[i], props[i].GetValue(registro));

            object id = comandoSql.ExecuteScalar();
            registro.id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }
        public void editar(int id, T registro)
        {
            string enderecoDB = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection(enderecoDB);
            conexaoComBanco.Open();
            SqlCommand comandoSql = new SqlCommand();
            comandoSql.Connection = conexaoComBanco;

            var props = propriedades();
            var nomesProps = nomesPropriedades(props);
            var linhaChaves = montarLinhas("[", "]", nomesProps);
            var linhaArroba = montarLinhas("@", "", nomesProps);

            string sqlcommand =
                $@"UPDATE {nomeTabela}
	                SET
  		                {String.Join(",\n", linhaChaves.concatenarLinhasSQL(linhaArroba))}
	                WHERE 
                        [ID] = @ID";
            comandoSql.CommandText = sqlcommand;

            for (int i = 0; i < props.Count; i++)
                comandoSql.Parameters.AddWithValue(nomesProps[i], props[i].GetValue(registro));
            comandoSql.Parameters.AddWithValue("ID", registro.id);

            comandoSql.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
        public void excluir(int id)
        {
            string enderecoDBTarefa = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection(enderecoDBTarefa);

            conexaoComBanco.Open();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;

            string sqlExclusao =
                $@"DELETE FROM {nomeTabela} 	                
	                WHERE 
		                [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", id);

            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }
        public T getById(int id)
        {
            return Registros.Find(x => x.id == id);
        }
        public List<T> registros()
        {
            string enderecoDB = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection(enderecoDB);
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;
            string sqlSelecao = $@"SELECT * FROM {nomeTabela}";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorRegistros = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();

            while (leitorRegistros.Read())
            {
                List<object> parametros = ObterParametros(leitorRegistros);
                var id = parametros.First();
                parametros.Remove(id);

                T registro = (T)Activator.CreateInstance(typeof(T), parametros.ToArray());
                registro.id = Convert.ToInt32(id);
                registros.Add(registro);
            }

            conexaoComBanco.Close();
            return registros;
        }
        private List<object> ObterParametros(IDataRecord linha)
        {
            List<object> parametros = new List<object>();
            for (int i = 0; i < linha.FieldCount; i++)
                parametros.Add(linha.GetValue(i));
            return parametros;
        }
        private List<String> montarLinhas(string esquerda, string direita, List<String> propriedadesEmString)
        {
            return propriedadesEmString.Select(x => esquerda + x + direita).ToList();
        }
        private List<PropertyInfo> propriedades()
        {
            return typeof(T).GetProperties().ToList();
        }
        private List<String> nomesPropriedades(List<PropertyInfo> propriedades)
        {
            return propriedades.Select(x => x.Name.ToString().ToUpper()).ToList();
        }
    }
}