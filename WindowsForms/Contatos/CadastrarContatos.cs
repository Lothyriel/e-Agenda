using e_Agenda.Controladores;
using e_Agenda.Dominio;
using System;
using System.Windows.Forms;

namespace WindowsForms.Contatos
{
    public partial class CadastrarContatos : Form
    {
        Contato contato;
        ControladorContatos controlador;
        public CadastrarContatos(ControladorContatos controlador, Contato contato = null)
        {
            this.contato = contato;
            this.controlador = controlador;
            InitializeComponent();
            if (contato != null)
                configurarParaEditar();
        }

        private void configurarParaEditar()
        {
            tb_cargo.Text = contato.cargo;
            tb_nome.Text = contato.nome;
            tb_empresa.Text = contato.empresa;
            tb_email.Text = contato.email;
            tb_telefone.Text = contato.telefone;
        }
        private void bt_cadastrar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato(tb_nome.Text, tb_email.Text, tb_telefone.Text, tb_empresa.Text, tb_cargo.Text);
            validar(contato);
        }
        private void validar(Contato contato)
        {
            string validacao = contato.validar();
            if (validacao == "ESTA_VALIDO")
            {
                salvar(contato);
                Dispose();
            }
            else
                MessageBox.Show(validacao);
        }
        private void salvar(Contato contato)
        {
            if (this.contato != null)
                controlador.editar(this.contato.id, contato);
            else
                controlador.inserir(contato);
        }
    }
}
