namespace GymTEC_API.Entidades
{
    public class Lesson_SHOWALL
    {
        public int ID_Lessons { get; set; }
        public string Branch_Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string instructor_id { get; set; } = string.Empty;
        public string service_id { get; set; } = string.Empty;
        public int Quotas { get; set; } = 0; //Cupos para el curso
    }
}
