namespace Embrace.API.Infrastructure.Persistence
{
    public class Voluntario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }

        public ICollection<VoluntarioAcao> Acoes { get; set; }
    }
}
