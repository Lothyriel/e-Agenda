using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Controle_de_Tarefas.Controladores
{
    abstract public class Controlador<T> where T : Entidade
    {
        protected abstract string nometabela { get; }
        public List<T> Registros => obterRegistros();

        public void inserir(T registro)
        {
            inserirOuEditar(new List<String> { "INSERT INTO", "", "VALUES", "SELECT SCOPE_IDENTITY();" }, registro);
        }
        public virtual void editar(int id, T registro)
        {
            inserirOuEditar(new List<String> { "UPDATE", "SET", "WHERE", "" }, registro);
        }
        public void excluir(int id)
        {
            string enderecoDBTarefa = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection(enderecoDBTarefa);

            conexaoComBanco.Open();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;

            string sqlExclusao =
                $@"DELETE FROM {nometabela} 	                
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
        public bool existsById(int id)
        {
            return getById(id) != null;
        }
        private List<T> obterRegistros()
        {
            string enderecoDB = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection(enderecoDB);
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;
            string sqlSelecao = $@"SELECT * FROM {nometabela}";
            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();
            var props = propriedades();
            var nomesProps = nomesPropriedades(props);

            while (leitorTarefas.Read())
            {
                List<object> parametros = ObterParametros(leitorTarefas, props, nomesProps);
                int id = (int)parametros[0];
                parametros.RemoveAt(0);

                T registro = (T)Activator.CreateInstance(typeof(T), parametros);
                registro.id = id;

                registros.Add(registro);
            }

            conexaoComBanco.Close();
            return registros;
        }
        private List<object> ObterParametros(SqlDataReader leitorTarefas, List<PropertyInfo> props,List<String> nomesProps)
        {
            List<object> parametros = new List<object>();

            for (int i = 0; leitorTarefas.Read(); i++)
                parametros.Add(Convert.ChangeType(leitorTarefas[nomesProps[i]], props[i].GetType()));

            return parametros;
        }
        private void inserirOuEditar(List<String> comandos, T registro)
        {
            string enderecoDB = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection(enderecoDB);
            conexaoComBanco.Open();
            SqlCommand comandoSql = new SqlCommand();
            comandoSql.Connection = conexaoComBanco;

            var props = propriedades();
            var nomesProps = nomesPropriedades(props);

            string sqlcommand =
                $@"{comandos[0]} {nometabela}
                    {comandos[1]}
                    (
                        {montarColunas("[", "]", nomesProps)}
                    ) 
                    {comandos[2]}
                    (
                        {(comandos[0] == "UPDATE" ? "[ID]=@ID" : montarColunas("@", "", nomesProps))}
                    );
                 {comandos[3]}";

            comandoSql.CommandText = sqlcommand;

            for (int i = 0; i < props.Count; i++)
                comandoSql.Parameters.AddWithValue(nomesProps[i], props[i].GetValue(registro));

            object id = comandoSql.ExecuteScalar();
            registro.id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }
        private string montarColunas(string esquerda, string direita, List<String> propriedadesEmString)
        {
            string strTabelas = "";
            propriedadesEmString.ForEach(x => strTabelas += esquerda + x + $"{direita},\n");
            return strTabelas.TrimEnd(new char[] { ',', '\n' });
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