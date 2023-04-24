namespace GymTEC_API.Entidades
{
    public class Lesson
    {
        public string ID_Lessons { get; set; } = string.Empty;
        public int Quotas { get; set; } = 0; //Cupos para el curso
        public string Type { get; set; } = string.Empty;
        public DateTime Start_Date { get; set; }
        public DateTime Final_Date { get; set; }
        //public Empleado Instructor { get; set; } = new Empleado();
        //public Cliente clientes_que_asisten_a_leccion { get; set; } = new Cliente();
        //public DateTime Inicio_Busqueda { get; set; } = DateTime.Now;
        //public DateTime Final_Busqueda { get; set; } = DateTime.Now;

    }
}
