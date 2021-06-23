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
        public SqlConnection conexaoComBanco { get => abrirConexaoDB(); }
        public List<T> Registros => obterRegistros();
        protected abstract string nomeTabela { get; }

        public T getById(int id)
        {
            return Registros.Find(x => x.id == id);
        }
        public void inserir(T registro)
        {
            SqlCommand comandoSql = new SqlCommand();
            comandoSql.Connection = conexaoComBanco;

            var props = propriedades();
            var nomesProps = nomesPropriedades(props);

            string sqlcommand =
                $@"INSERT INTO {nomeTabela}
                    (
                    {String.Join(",\n", montarLinhas("[", "]", nomesProps))}
                    )
                    VALUES
                    (
                    {String.Join(",\n", montarLinhas("@", "", nomesProps))}
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
            SqlCommand comandoSql = new SqlCommand();
            comandoSql.Connection = conexaoComBanco;

            var props = propriedades();
            var nomesProps = nomesPropriedades(props);
            var linhaChaves = montarLinhas("[", "]", nomesProps);
            var linhaArroba = montarLinhas("@", "", nomesProps);

            string sqlcommand =
                $@"UPDATE {nomeTabela}
	                SET
  		                {String.Join(",\n", combinarListas(linhaChaves, linhaArroba, "="))}
	                WHERE 
                        [ID] = @ID";
            comandoSql.CommandText = sqlcommand;

            for (int i = 0; i < props.Count; i++)
                comandoSql.Parameters.AddWithValue(nomesProps[i], props[i].GetValue(registro));
            comandoSql.Parameters.AddWithValue("ID", id);

            comandoSql.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
        public void excluir(int id)
        {
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
        public List<T> obterRegistros()
        {
            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao = $@"SELECT * FROM {nomeTabela}";
            comandoSelecao.CommandText = sqlSelecao;
            SqlDataReader leitorRegistros = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();

            while (leitorRegistros.Read())
            {
                List<object> camposDB = leitorRegistros.ObterCamposDB();

                T registro = (T)Activator.CreateInstance(typeof(T), camposDB.ToArray());
                registros.Add(registro);
            }

            conexaoComBanco.Close();
            return registros;
        }

        private SqlConnection abrirConexaoDB()
        {
            string enderecoDB = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection(enderecoDB);
            conexaoComBanco.Open();
            return conexaoComBanco;
        }
        private List<String> combinarListas(List<String> lista1, List<String> lista2, String separador)
        {
            Queue<string> var = new Queue<string>();
            lista2.ForEach(x => var.Enqueue(x));

            return lista1.Select(x => x + separador + var.Dequeue()).ToList();
        }
        private List<String> montarLinhas(String esquerda, String direita, List<String> propriedadesEmString)
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