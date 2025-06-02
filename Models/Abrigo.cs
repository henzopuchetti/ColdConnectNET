namespace ColdConnectNET.API.Models
{
    public class Abrigo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;

        public List<Ocorrencia> Ocorrencias { get; set; } = new();
    }
}
