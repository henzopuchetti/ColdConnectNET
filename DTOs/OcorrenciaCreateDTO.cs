namespace ColdConnectNET.API.DTOs
{
    public class OcorrenciaCreateDTO
    {
        public string Tipo { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public int AbrigoId { get; set; }
    }
}
