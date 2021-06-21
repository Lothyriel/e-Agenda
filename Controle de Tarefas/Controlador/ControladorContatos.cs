using Controle_de_Tarefas.Dominio;

namespace Controle_de_Tarefas.Controladores
{
    public class ControladorContatos : Controlador<Contato>
    {
        protected override string nomeTabela => "TBContatos";
    }
}