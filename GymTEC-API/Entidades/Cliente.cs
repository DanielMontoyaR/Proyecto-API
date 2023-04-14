namespace GymTEC_API.Entidades
{
    public class Cliente
    {
        public string Cedula_cliente { get; set; } = string.Empty;
        public string Canton { get; set;} = string.Empty;
        public string Distrito { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public int Peso { get; set; } = 0;
        public int IMC { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string S_Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string Apellido2 { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Fecha_Nacimiento { get; set; } = string.Empty;
        public List<Leccion> lecciones_que_asiste { get; set; } = new List<Leccion>();
        //public string Dia { get; set; } = string.Empty;
        //public string Mes { get; set; } = string.Empty;
        //public string Año { get; set; } = string.Empty;

    }
}
