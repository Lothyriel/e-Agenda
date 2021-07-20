using e_Agenda.Controladores;
using e_Agenda.Dominio;
using System.Collections.Generic;
using System.Windows.Forms;
using static e_Agenda.Controladores.ControladorTarefas;
using System;

namespace WindowsForms.Tarefas
{
    public partial class TelaObjetivos : Form
    {
        private Tarefa tarefa;
        private ControladorObjetivos controlador;
        public TelaObjetivos(Tarefa tarefa)
        {
            this.tarefa = tarefa;
            controlador = new ControladorObjetivos();

            InitializeComponent();
            carregarCheckedListBox();
            //components
            tbar_prioridade.Value = tarefa.prioridade;
            tb_titulo.Text = tarefa.titulo;
            bt_salvar.Enabled = false;
            lb_percentual.Text = tbar_prioridade.Value.ToString();
            atualizaBarraProgresso();
        }

        private void atualizaBarraProgresso()
        {
            pb_percentual.Value = tarefa.porcentagem_conclusao;
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            tarefa.titulo = tb_titulo.Text;
            tarefa.prioridade = tbar_prioridade.Value;
            string validacao = tarefa.validar();
            if (validacao == "ESTA_VALIDO")
            {
                new ControladorTarefas().editar(tarefa.id, tarefa);
                bt_salvar.Enabled = false;
                MessageBox.Show("Sucesso!");
            }
            else
                MessageBox.Show(validacao);
        }
        private void tbar_prioridade_Scroll(object sender, EventArgs e)
        {
            lb_percentual.Text = tbar_prioridade.Value.ToString();
            bt_salvar.Enabled = true;
        }
        private void bt_cadastrarObjetivos_Click(object sender, EventArgs e)
        {
            Objetivo objetivo = new Objetivo(tb_tituloObjetivo.Text, tarefa.id);
            string validacao = tarefa.validar();
            if (validacao == "ESTA_VALIDO")
            {
                tarefa.addObjetivo(objetivo);
                controlador.inserir(objetivo);
                carregarCheckedListBox();
                limparTextBox();
            }
            else
                MessageBox.Show(validacao);
        }

        private void limparTextBox()
        {
            tb_tituloObjetivo.Clear();
        }
        private void tb_titulo_TextChanged(object sender, EventArgs e)
        {
            bt_salvar.Enabled = true;
        }
        private void clb_objetivos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clb_objetivos.SelectedItem != null)
                marcarObjetivo();
        }

        private void carregarCheckedListBox()
        {
            clb_objetivos.Items.Clear();
            foreach (var item in tarefa.objetivos)
                clb_objetivos.Items.Add(item, item.finalizado);

            atualizaBarraProgresso();
        }
        private void marcarObjetivo()
        {
            var objetivo = (Objetivo)clb_objetivos.SelectedItem;
            objetivo.finalizado ^= true;
            tarefa.atualizaConclusao();
            controlador.editar(objetivo.id, objetivo);
            atualizaBarraProgresso();
        }
    }
}
