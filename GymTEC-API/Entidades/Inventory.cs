namespace GymTEC_API.Entidades
{
    public class Inventory
    {

        public string Branch_Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;//Marca
        public int Serial_Number { get; set; } = 0;//PK
        public string Price { get; set; } = string.Empty;
        public int gear_ID { get; set;} = 0; //Connector with GearAvailable
        public string gear_Name { get; set; } = string.Empty;
        public string gear_Type { get; set; } = string.Empty;
    }
}
