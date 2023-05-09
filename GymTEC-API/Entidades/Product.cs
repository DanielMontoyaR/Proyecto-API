namespace GymTEC_API.Entidades
{
    public class Product
    {
        public string Barcode { get; set; } = string.Empty; //PK

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int price { get; set; } = 0;

        public string branch_Name { get; set; } = string.Empty;
    }
}
