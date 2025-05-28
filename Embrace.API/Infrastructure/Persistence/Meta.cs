namespace Embrace.API.Infrastructure.Persistence
{
    public class Meta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEsperada { get; set; }
        public int AcaoSolidariaId { get; set; }

        public AcaoSolidaria AcaoSolidaria { get; set; }
    }
}
