namespace GymTEC_API.Entidades
{
    public class Servicio
    {
        public string ID_Servicio { get; set; } = string.Empty; //Key Value
        public string Tipo_Servicio { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public Leccion leccion_disponible { get; set; } = new Leccion();
    }
}
