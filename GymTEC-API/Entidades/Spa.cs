namespace GymTEC_API.Entidades
{
    public class Spa
    {

        public string Branch_Name { get; set; } = string.Empty;

        public char Status { get; set; }

        public Treatment Spa_Treatment { get; set; } = new Treatment();



    }
}
