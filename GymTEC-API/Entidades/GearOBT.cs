namespace GymTEC_API.Entidades
{
    public class GearOBT
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int gear_ID { get; set; } = 0; //PK
        public string Gear_Type { get; set; } = string.Empty;
    }
}
