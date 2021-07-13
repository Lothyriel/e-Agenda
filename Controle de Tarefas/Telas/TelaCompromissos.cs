using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;

namespace Controle_de_Tarefas.Telas
{
    class TelaCompromissos : Tela<Compromisso>
    {
        private new ControladorCompromissos controlador = new ControladorCompromissos();
        private ControladorContatos ccontat = new ControladorContatos();

        public TelaCompromissos() : base(new ControladorCompromissos()) { }
        public override Compromisso registroValido()
        {
            Console.Clear();
            String assunto;
            String local;
            DateTime data_inicio;
            DateTime hora;
            Contato contato;

            String strContato;

            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite o assunto do compromisso\n");
                assunto = Console.ReadLine();
                if (assunto.Length > 0)
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nAssunto não pode ser nulo");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite o local do compromisso\n");
                local = Console.ReadLine();
                if (local.Length > 0)
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nLocal não pode ser nulo");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite a data do compromisso\n");
                String strData = Console.ReadLine();
                if (DateTime.TryParse(strData, out data_inicio) && data_inicio > DateTime.Now)
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nDigite uma data válida");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite a hora do compromisso\n");
                String strHora = Console.ReadLine();
                if (DateTime.TryParse(strHora, out hora))
                {
                    data_inicio = new DateTime(data_inicio.Year, data_inicio.Month, data_inicio.Day, hora.Hour, hora.Minute, 0);
                    break;
                }
                TipoMensagem.Erro.mostrarMensagem("\nDigite um horário válido no formato hh:mm");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite o horário de término do compromisso\n");
                String strHora = Console.ReadLine();
                if (DateTime.TryParse(strHora, out hora))
                {
                    hora = new DateTime(data_inicio.Year, data_inicio.Month, data_inicio.Day, hora.Hour, hora.Minute, 0);
                    if (hora > data_inicio)
                        break;
                }
                TipoMensagem.Erro.mostrarMensagem("\nDigite um horário válido no formato hh:mm");
            }

            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite um contato para o compromisso ou S para terminar o cadastro\n");
                strContato = new TelaContatos().obterOpcao();
                if (strContato != "S")
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nDigite um ID válido ou então S");
            }
            contato = strContato != "S" ? ccontat.getById(Convert.ToInt32(strContato)) : null;

            return new Compromisso(assunto, local, data_inicio, hora, contato);
        }
        public override void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para o menu visualização de compromissos");
                Console.WriteLine("Digite 2 para cadastrar um novo compromisso");
                Console.WriteLine("Digite 3 para editar um compromisso");
                Console.WriteLine("Digite 4 para excluir um compromisso\n");
                Console.WriteLine("Digite S para Voltar\n");
                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": menuVisualizar(); break;
                    case "2": cadastrar(); break;
                    case "3": editar(); break;
                    case "4": excluir(); break;
                    case "S": break;
                    default: TipoMensagem.Erro.mostrarMensagem("\nSelecione uma opcão correta!"); break;
                }
            }
        }

        private void menuVisualizar()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para visualizar compromissos futuros");
                Console.WriteLine("Digite 2 para visualizar compromissos passados");
                Console.WriteLine("Digite 3 para visualizar todos os compromissos cadastrados\n");
                Console.WriteLine("Digite S para Voltar\n");
                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": visualizarFuturos(); break;
                    case "2": visualizar(controlador.compromissosPassados()); break;
                    case "3": visualizar(); break;
                    case "S": break;
                    default: TipoMensagem.Erro.mostrarMensagem("\nSelecione uma opcão correta!"); break;
                }
            }
        }
        private void visualizarFuturos()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para visualizar compromissos nos próximos 7 dias");
                Console.WriteLine("Digite 2 para visualizar compromissos no próximo mês");
                Console.WriteLine("Digite 3 para visualizar todos os compromissos até certa data\n");
                Console.WriteLine("Digite S para Voltar\n");
                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": visualizar(controlador.filtrarPorPeriodo(new TimeSpan(7, 0, 0, 0, 0))); break;
                    case "2": visualizar(controlador.filtrarPorPeriodo(new TimeSpan(28, 0, 0, 0, 0))); break;
                    case "3": visualizar(controlador.compromissosFuturos(getDate())); break;
                    case "S": break;
                    default: TipoMensagem.Erro.mostrarMensagem("\nSelecione uma opcão correta!"); break;
                }
            }
        }
        private DateTime getDate()
        {
            DateTime date;
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite uma data para filtrar compromissos\n");
                String strDate = Console.ReadLine();
                if (DateTime.TryParse(strDate, out date))
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nDigite uma data válida");
            }
            return date;
        }
    }
}
