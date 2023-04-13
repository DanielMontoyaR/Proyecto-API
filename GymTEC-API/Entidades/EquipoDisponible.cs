namespace GymTEC_API.Entidades
{
    public class EquipoDisponible
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public TipoEquipo id_Equipo { get; set; } = new TipoEquipo();

    }
}
