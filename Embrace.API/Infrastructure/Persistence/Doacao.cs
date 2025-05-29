namespace Embrace.API.Infrastructure.Persistence
{
    public class Doacao
    {
        public long Id { get; set; }
        public string Tipo { get; set; } // Roupas, Alimentos, etc.
        public int Quantidade { get; set; }
        public DateTime DataRecebida { get; set; }

        public long AcaoSolidariaId { get; set; }
        public AcaoSolidaria AcaoSolidaria { get; set; }
    }
}
