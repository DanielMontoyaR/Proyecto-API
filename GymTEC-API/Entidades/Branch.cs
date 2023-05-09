namespace GymTEC_API.Entidades
{
    public class Branch
    {
        public string Name { get; set; } = string.Empty; //PK of branch 

        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public int max_Size { get; set; } = 0;
        public string opening_Date { get; set; }= string.Empty;
        public string schedule_Attention { get; set; } = string.Empty;
        
    }
}
