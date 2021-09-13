using e_Agenda.Controladores;
using e_Agenda.Dominio;
using System;
using System.Windows.Forms;

namespace WindowsForms.Compromissos
{
    public partial class CadastrarCompromissos : Form
    {
        ControladorCompromissos controlador;
        ControladorContatos controladorContatos;
        Compromisso compromisso;
        public CadastrarCompromissos(ControladorCompromissos controlador, Compromisso compromisso = null)
        {
            this.controlador = controlador;
            this.compromisso = compromisso;
            controladorContatos = new ControladorContatos();
            InitializeComponent();
            carregarListBox();
            if (compromisso != null)
                configurarParaEditar();
        }

        private void carregarListBox()
        {
            lb_contatos.Items.Add("Sem Contato");
            controladorContatos.Registros.ForEach(x => lb_contatos.Items.Add(x));
        }
        private void configurarParaEditar()
        {
            tb_assunto.Text = compromisso.assunto;
            tb_local.Text = compromisso.local;
            dtp_horaFim.Value = compromisso.data_fim;
            dtp_data.Value = compromisso.data_inicio;
            if (compromisso.contato == null)
                lb_contatos.SelectedItem = "Sem Contato";
            else
                lb_contatos.SelectedItem = compromisso.contato;
        }
        private void bt_cadastrar_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = dtp_data.Value.Date;
            dataInicio = dataInicio.Add(dtp_horaInicio.Value.TimeOfDay);

            DateTime dataFim = dtp_data.Value.Date;
            dataFim = dataFim.Add(dtp_horaFim.Value.TimeOfDay);

            Compromisso compromisso = new Compromisso(tb_assunto.Text, tb_local.Text, dataInicio, dataFim, lb_contatos.SelectedItem as Contato);
            validar(compromisso);
        }
        private void validar(Compromisso compromisso)
        {
            string validacao = compromisso.validar();
            if (validacao != "ESTA_VALIDO")
            {
                MessageBox.Show(validacao);
                return;
            }
            if (!controlador.horarioDisponivel(compromisso))
            {
                MessageBox.Show("Já existe um compromisso cadastrado neste horário!");
                return;
            }
            salvar(compromisso);
            Dispose();
        }
        private void salvar(Compromisso compromisso)
        {
            if (this.compromisso != null)
                controlador.editar(this.compromisso.id, compromisso);
            else
                controlador.inserir(compromisso);
        }
    }
}
