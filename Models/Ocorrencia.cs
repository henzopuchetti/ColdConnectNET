namespace ColdConnectNET.API.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime Data { get; set; }

        public int AbrigoId { get; set; }
        
        public Abrigo Abrigo { get; set; } = null!;
    }
}
