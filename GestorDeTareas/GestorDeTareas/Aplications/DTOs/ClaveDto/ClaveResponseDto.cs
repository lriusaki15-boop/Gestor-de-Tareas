namespace GestorDeTareas.Aplications.DTOs.ClaveDto
{
    public class ClaveResponseDto
    {
        public string Clave { get; set; } = string.Empty;
        public DateTime Expira { get; set; }
        public string Nombre { get; set; }
        public long Id { get; set; }

        public ClaveResponseDto(){ }

        public ClaveResponseDto (string clave, DateTime expira, string nombre, long id)
        {
            this.Clave = clave;
            this.Expira = expira;
            this.Nombre = nombre;
            this.Id = id;
        }
    }
}
