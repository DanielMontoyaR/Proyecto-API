namespace GymTEC_API.Entidades
{
    public class Inventario
    {
        public string Marca { get; set; } = string.Empty;//Atributo llave
        public int Numero_Serie { get; set; } = 0;//Atributo llave
        public string Costo { get; set; } = string.Empty;

        public EquipoDisponible equipo_Id { get; set; } = new EquipoDisponible();
    }
}
