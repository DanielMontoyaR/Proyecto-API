namespace GymTEC_API.Entidades
{
    public class Inventory
    {

        public string Branch_Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;//Marca, Atributo llave
        public int Serial_Number { get; set; } = 0;//Atributo llave
        public string Price { get; set; } = string.Empty;
        public int gear_ID { get; set;} = 0; //Conector con GearAvailable

        //public GearAvailable Gear_Id { get; set; } = new GearAvailable();
    }
}
