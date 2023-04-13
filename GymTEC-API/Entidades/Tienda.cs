namespace GymTEC_API.Entidades
{
    public class Tienda
    {
        public bool Status { get; set; } = false;

        public Producto producto_Tienda { get; set; } = new Producto();
    }
}
