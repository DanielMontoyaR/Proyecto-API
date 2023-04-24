namespace GymTEC_API.Entidades
{
    public class Inventory
    {
        public string Brand { get; set; } = string.Empty;//Marca, Atributo llave
        public int Serial_Number { get; set; } = 0;//Atributo llave
        public string Price { get; set; } = string.Empty;

        public GearAvailable Gear_Id { get; set; } = new GearAvailable();
    }
}
