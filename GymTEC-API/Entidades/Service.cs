namespace GymTEC_API.Entidades
{
    public class Service
    {
        public string ID_Service { get; set; } = string.Empty; //Key Value
        public string Service_Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Lesson Lesson_Available { get; set; } = new Lesson();
    }
}
