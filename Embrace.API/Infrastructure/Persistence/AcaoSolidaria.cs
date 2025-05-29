namespace Embrace.API.Infrastructure.Persistence
{
    public class AcaoSolidaria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoEvento { get; set; } // ex: Frio, Enchente
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Descricao { get; set; }
        public int MetaItens { get; set; }

        public int OngId { get; set; }
        public Ong Ong { get; set; }

        public ICollection<Doacao> Doacoes { get; set; }
        public ICollection<VoluntarioAcao> Voluntarios { get; set; }
    }
}
