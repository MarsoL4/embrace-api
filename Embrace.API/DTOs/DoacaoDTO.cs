namespace Embrace.API.DTOs
{
    public class DoacaoDTO
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataRecebida { get; set; }

        public long AcaoSolidariaId { get; set; }
    }
}