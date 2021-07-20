using e_Agenda.Controladores;
using e_Agenda.Dominio;
using System;
using System.Windows.Forms;

namespace WindowsForms.Contatos
{
    public partial class CadastrarContatos : Form
    {
        public CadastrarContatos(ControladorContatos controlador, Contato contato = null)
        {
            InitializeComponent();
            if (contato != null)
                configurarParaEditar();
        }

        private void configurarParaEditar()
        {
            throw new NotImplementedException();
        }
    }
}
