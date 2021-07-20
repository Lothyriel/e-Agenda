using System;
using System.Windows.Forms;
using WindowsForms.Compromissos;
using WindowsForms.Contatos;
using WindowsForms.Tarefas;

namespace WindowsForms
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void tarefas_Click(object sender, EventArgs e)
        {
            Hide();
            using (TelaTarefas tela = new TelaTarefas()) { tela.ShowDialog(); }
            Show();
        }
        private void compromissos_Click(object sender, EventArgs e)
        {
            Hide();
            using (TelaCompromissos tela = new TelaCompromissos()) { tela.ShowDialog(); }
            Show();
        }
        private void contatos_Click(object sender, EventArgs e)
        {
            Hide();
            using (TelaContatos tela = new TelaContatos()) { tela.ShowDialog(); }
            Show();
        }
    }
}
