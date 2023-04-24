namespace GymTEC_API.Entidades
{
    public class Product
    {
        public string Barcode { get; set; } = string.Empty; //Atributo llave de la entidad Producto

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
