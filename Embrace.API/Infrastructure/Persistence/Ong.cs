namespace Embrace.API.Infrastructure.Persistence
{
    public class Ong
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public ICollection<AcaoSolidaria> Acoes { get; set; }
    }
}
