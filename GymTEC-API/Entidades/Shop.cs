namespace GymTEC_API.Entidades
{
    public class Shop
    {
        public string Branch_Name { get; set; } = string.Empty; //FK
        public string Status { get; set; } = string.Empty;

        //public Product Shop_Product { get; set; } = new Product();
    }
}
