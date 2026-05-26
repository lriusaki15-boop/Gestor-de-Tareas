namespace GestorDeTareas.Aplications.DTOs.ClaveDto
{
    public class ClaveResponseDto
    {
        public string Clave { get; set; } = string.Empty;
        public DateTime Expira { get; set; }

        public ClaveResponseDto(){ }

        public ClaveResponseDto (string clave, DateTime expira)
        {
            this.Clave = clave;
            this.Expira = expira;
        }
    }
}
