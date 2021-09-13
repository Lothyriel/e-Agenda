namespace e_Agenda.Dominio
{
    /// <summary>
    /// Classe abstrata Entidade
    /// </summary>
    public abstract class Entidade
    {
        public int id { get; set; }

        /// <summary>
        /// Método para validar a entidade.
        /// </summary>
        /// <returns>A string.</returns>
        public abstract string validar();
    }
}