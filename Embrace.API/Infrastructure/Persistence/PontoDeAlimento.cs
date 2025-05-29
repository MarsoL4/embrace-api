namespace Embrace.API.Infrastructure.Persistence
{
    public class PontoDeAlimento
    {
        public long Id { get; set; }
        public string NomeLocal { get; set; }
        public string Endereco { get; set; }
        public int Capacidade { get; set; } // quantos kits por exemplo
    }
}
