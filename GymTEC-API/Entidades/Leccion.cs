namespace GymTEC_API.Entidades
{
    public class Leccion
    {
        public string ID_Lecciones { get; set; } = string.Empty;
        public int Cupos { get; set; } = 0;
        public string Tipo { get; set; } = string.Empty;
        public DateTime Fecha_Inicio { get; set; } = DateTime.Now;
        public DateTime Fecha_Final { get; set; } = DateTime.Now;
        public Empleado Instructor { get; set; } = new Empleado();
        public Cliente clientes_que_asisten_a_leccion { get; set; } = new Cliente();
        //public DateTime Inicio_Busqueda { get; set; } = DateTime.Now;
        //public DateTime Final_Busqueda { get; set; } = DateTime.Now;

    }
}
