namespace Embrace.API.Infrastructure.Persistence
{
    public class Meta
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEsperada { get; set; }
        public long AcaoSolidariaId { get; set; }

        public AcaoSolidaria AcaoSolidaria { get; set; }
    }
}
