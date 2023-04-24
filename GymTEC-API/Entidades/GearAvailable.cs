namespace GymTEC_API.Entidades
{
    public class GearAvailable
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public GearType id_Gear { get; set; } = new GearType();

    }
}
