namespace GymTEC_API.Entidades
{
    public class Lesson
    {
        public int ID_Lessons { get; set; } = 0;
        public string Branch_Name { get; set; } = string.Empty;
        public int Quotas { get; set; } = 0; //Cupos 
        public string Type { get; set; } = string.Empty;
        public string Start_Date { get; set; } = string.Empty;
        public string Final_Date { get; set; } = string.Empty;
        public string search_Date { get; set; } = string.Empty;
        public string search_End { get; set; } = string.Empty;
        public string instructor_id { get; set; } = string.Empty;
        public string service_id { get; set; } = string.Empty;

        

    }
}
