namespace GymTEC_API.Entidades
{
    public class Inventory_ALL
    {
        public string Branch_Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;//Marca, PK
        public int Serial_Number { get; set; } = 0;//PK
        public string Price { get; set; } = string.Empty;
    }
}
