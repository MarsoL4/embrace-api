namespace Embrace.API.Infrastructure.Persistence
{
    public class VoluntarioAcao
    {
        public int VoluntarioId { get; set; }
        public Voluntario Voluntario { get; set; }

        public int AcaoSolidariaId { get; set; }
        public AcaoSolidaria AcaoSolidaria { get; set; }
    }
}
