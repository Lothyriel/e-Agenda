using e_Agenda.Controladores;
using e_Agenda.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms.Compromissos
{
    public partial class TelaCompromissos : Form
    {
        ControladorCompromissos controlador;
        public TelaCompromissos()
        {
            InitializeComponent();
            controlador = new ControladorCompromissos();
            changeButtons(false);
            carregarTabelas();
        }
        public DataTable carregarTabela(List<Compromisso> fonte)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("ID");
            tabela.Columns.Add("Assunto");
            tabela.Columns.Add("Contato");
            tabela.Columns.Add("Local");
            tabela.Columns.Add("Data");
            tabela.Columns.Add("Hora Início");
            tabela.Columns.Add("Hora Fim");

            List<Compromisso> compromissos = fonte;

            foreach (var compromisso in compromissos)
            {
                var linha = tabela.NewRow();
                linha["ID"] = compromisso.id;
                linha["Assunto"] = compromisso.assunto;
                linha["Contato"] = compromisso.contato?.nome;
                linha["Local"] = compromisso.local;
                linha["Data"] = compromisso.data_inicio.ToString("d");
                linha["Hora Início"] = compromisso.data_inicio.ToString("t");
                linha["Hora Fim"] = compromisso.data_fim.ToString("t");

                tabela.Rows.Add(linha);
            }
            return tabela;
        }
        private void bt_cadastro_Click(object sender, EventArgs e)
        {
            Hide();
            using (CadastrarCompromissos tela = new CadastrarCompromissos(controlador)) { tela.ShowDialog(); }
            carregarTabelas();
            Show();
        }
        private void bt_editar_Click(object sender, EventArgs e)
        {
            Hide();
            Compromisso compromisso = controlador.getById(getIdSelecionadoTabela());
            using (CadastrarCompromissos tela = new CadastrarCompromissos(controlador, compromisso)) { tela.ShowDialog(); }
            carregarTabelas();
            Show();
        }
        private void bt_excluir_Click(object sender, EventArgs e)
        {
            controlador.excluir(getIdSelecionadoTabela());
            carregarTabelas();
            changeButtons(false);
        }
        private int getIdSelecionadoTabela()
        {
            DataGridView dg_selecionado = (DataGridView)tabControl.SelectedTab.GetChildAtPoint(new Point(dg_visualizarPassados.Size));
            return Convert.ToInt32(dg_selecionado.CurrentRow.Cells[0].Value);
        }
        private void dg_visualizar_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            changeButtons(true);
        }
        private void changeButtons(bool estado)
        {
            bt_excluir.Enabled = estado;
            bt_editar.Enabled = estado;
        }
        private void carregarTabelas()
        {
            dg_visualizarFuturos.DataSource = carregarTabela(controlador.compromissosFuturos());
            dg_visualizarPassados.DataSource = carregarTabela(controlador.compromissosPassados());
        }
    }
}
