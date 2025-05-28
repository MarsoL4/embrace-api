namespace Embrace.API.Infrastructure.Persistence
{
    public class Doacao
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Quantidade { get; set; }

        public int AcaoSolidariaId { get; set; }
        public AcaoSolidaria AcaoSolidaria { get; set; }
    }
}
