namespace GymTEC_API.Entidades
{
    public class Shop
    {
        public char Status { get; set; }

        public Product Shop_Product { get; set; } = new Product();
    }
}
