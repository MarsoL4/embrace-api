namespace Embrace.API.Infrastructure.Persistence
{
    public class AcaoSolidaria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string TipoEvento { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public int OngId { get; set; }
        public Ong Ong { get; set; }

        public ICollection<Doacao> DoacoesRecebidas { get; set; }
    }
}
