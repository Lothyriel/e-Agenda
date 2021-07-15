namespace e_Agenda.Dominio
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
        public string nome { get; private set; }
        public string email { get; private set; }
        public string telefone { get; private set; }
        public string empresa { get; private set; }
        public string cargo { get; private set; }

        public override string ToString()
        {
            return $"ID: {id} | Nome: {nome} | Email: {email} | Telefone: {telefone} | Empresa: {empresa} | Cargo: {cargo}";
        }
    }
}