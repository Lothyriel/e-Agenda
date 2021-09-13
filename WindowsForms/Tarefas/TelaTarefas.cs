using e_Agenda.Controladores;
using e_Agenda.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms.Tarefas
{
    public partial class TelaTarefas : Form
    {
        ControladorTarefas controlador;
        public TelaTarefas()
        {
            InitializeComponent();
            controlador = new ControladorTarefas();
            carregarTabelas();
        }
        public DataTable carregarTabela(List<Tarefa> fonte)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("ID");
            tabela.Columns.Add("Título");
            tabela.Columns.Add("Prioridade");
            tabela.Columns.Add("Percentual de Conclusão");
            tabela.Columns.Add("Data Criação");
            tabela.Columns.Add("Data Conclusão");

            List<Tarefa> tarefas = fonte;

            foreach (var tarefa in tarefas)
            {
                var linha = tabela.NewRow();
                linha["ID"] = tarefa.id;
                linha["Título"] = tarefa.titulo;
                linha["Prioridade"] = tarefa.prioridade;
                linha["Percentual de Conclusão"] = tarefa.porcentagem_conclusao;
                linha["Data Criação"] = tarefa.dt_criacao.ToString("d");
                linha["Data Conclusão"] = tarefa.dt_conclusao != new DateTime(1753, 1, 1) ? tarefa.dt_conclusao.ToString("d") : "Não Finalizada";

                tabela.Rows.Add(linha);
            }
            return tabela;
        }
        private void bt_cadastro_Click(object sender, EventArgs e)
        {
            Hide();
            using (CadastrarTarefas tela = new CadastrarTarefas(controlador)) { tela.ShowDialog(); }
            carregarTabelas();
            Show();
        }
        private int getIdSelecionadoTabela()
        {
            DataGridView dg_selecionado = (DataGridView)tabControl.SelectedTab.GetChildAtPoint(new Point(dg_visualizarConcluidas.Size));
            return Convert.ToInt32(dg_selecionado.CurrentRow.Cells[0].Value);
        }
        private void bt_excluir_Click(object sender, EventArgs e)
        {
            controlador.excluir(getIdSelecionadoTabela());
            carregarTabelas();
            changeButtons(false);
        }
        private void dg_visualizar_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            changeButtons(true);
        }
        private void changeButtons(bool estado)
        {
            bt_excluir.Enabled = estado;
        }
        private void carregarTabelas()
        {
            dg_visualizarConcluidas.DataSource = carregarTabela(controlador.tarefasCompletas());
            dg_visualizarInconcluidas.DataSource = carregarTabela(controlador.tarefasIncompletas());
        }
        private void dg_selecionado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Hide();
            Tarefa selecionada = controlador.getById(getIdSelecionadoTabela());
            using (TelaObjetivos tela = new TelaObjetivos(selecionada)) { tela.ShowDialog(); }
            controlador.editar(selecionada.id, selecionada);
            carregarTabelas();
            Show();
        }
    }
}
