namespace e_Agenda.Dominio
{
    public abstract class Entidade
    {
        public int id { get; set; }

        public abstract string validar();
    }
}