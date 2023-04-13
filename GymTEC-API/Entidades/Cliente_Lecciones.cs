namespace GymTEC_API.Entidades
{
    public class Cliente_Lecciones //Entidad creada para ver cuales clientes asisten a x clase.
    {
        public Cliente clientes_que_asisten { get; set; } = new Cliente();
        public Leccion lecciones { get; set; } = new Leccion();
    }
}
