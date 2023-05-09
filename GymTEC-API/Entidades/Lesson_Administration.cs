namespace GymTEC_API.Entidades
{
    public class Lesson_Administration
    {
        public int ID_Lessons { get; set; } = 0;
        public string Branch_Name { get; set; } = string.Empty;
        public int Quotas { get; set; } = 0; //Cupos 
        public string Start_Date { get; set; }
        public string Final_Date { get; set; }
        public string instructor_id { get; set; } = string.Empty;
        public string service_id { get; set; } = string.Empty;
        public string service_desc { get; set; } = string.Empty;
        public string client_id { get; set; } = string.Empty;
    }
}
