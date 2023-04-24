namespace GymTEC_API.Entidades
{
    public class Client_Lessons //Entidad creada para ver cuales clientes asisten a x clase.
    {
        public Client Assisting_Clients { get; set; } = new Client();
        public Lesson lessons { get; set; } = new Lesson();
    }
}
