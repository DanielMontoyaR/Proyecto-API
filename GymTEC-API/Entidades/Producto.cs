namespace GymTEC_API.Entidades
{
    public class Producto
    {
        public string Codigo_Barras { get; set; } = string.Empty; //Atributo llave de la entidad Producto

        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
