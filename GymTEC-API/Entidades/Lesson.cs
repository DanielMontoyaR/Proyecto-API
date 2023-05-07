namespace GymTEC_API.Entidades
{
    public class Lesson
    {
        public int ID_Lessons { get; set; } = 0;
        public string Branch_Name { get; set; } = string.Empty;
        public int Quotas { get; set; } = 0; //Cupos para el curso
        public string Type { get; set; } = string.Empty;
        public string Start_Date { get; set; } = string.Empty;
        public string Final_Date { get; set; } = string.Empty;
        public string search_Date { get; set; } = string.Empty;
        public string search_End { get; set; } = string.Empty;
        public string instructor_id { get; set; } = string.Empty;
        public string service_id { get; set; } = string.Empty;

        //public Empleado Instructor { get; set; } = new Empleado();
        //public Cliente clientes_que_asisten_a_leccion { get; set; } = new Cliente();
        //public DateTime Inicio_Busqueda { get; set; } = DateTime.Now;
        //public DateTime Final_Busqueda { get; set; } = DateTime.Now;

    }
}
