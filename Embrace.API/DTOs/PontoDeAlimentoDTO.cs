namespace Embrace.API.DTOs
{
    public class PontoDeAlimentoDTO
    {
        public long Id { get; set; }
        public string NomeLocal { get; set; }
        public string Endereco { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Capacidade { get; set; }
    }
}