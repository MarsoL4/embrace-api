namespace Embrace.API.DTOs
{
    public class AcaoSolidariaDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string TipoEvento { get; set; } // ex: Enchente, Frio
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Descricao { get; set; }
        public int MetaItens { get; set; }

        public long OngId { get; set; }
    }
}