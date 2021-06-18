namespace Controle_de_Tarefas.Dominio
{
    public class Contato : Entidade
    {
        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.empresa = empresa;
            this.cargo = cargo;
        }
        private string nome;
        private string email;
        private string telefone;
        private string empresa;
        private string cargo;

        public override string ToString()
        {
            return $"Nome: {nome} | Email: {email} | Telefone: {telefone} | Empresa: {empresa} | Cargo: {cargo} | ";
        }
    }
}