using System.Text.RegularExpressions;

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
            return $"{nome} | {email} | {telefone}";
        }
        public string ToString(string format)
        {
            return $"ID: {id} | Nome: {nome} | Email: {email} | Telefone: {telefone} | Empresa: {empresa} | Cargo: {cargo}";
        }
        public override string validar()
        {
            Regex templateEmail = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            Regex templateTelefone = new Regex(@"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})");

            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao = "O campo Nome é obrigatório";

            if (string.IsNullOrEmpty(cargo))
                resultadoValidacao = "\nO campo Cargo é obrigatório";

            if (string.IsNullOrEmpty(empresa))
                resultadoValidacao = "\nO campo Empresa é obrigatório";

            if (!templateTelefone.IsMatch(telefone))
                resultadoValidacao = "O campo Telefone está inválido";

            if (!templateEmail.IsMatch(email))
                resultadoValidacao += "\nO campo Email está inválido";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}