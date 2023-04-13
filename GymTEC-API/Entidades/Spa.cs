namespace GymTEC_API.Entidades
{
    public class Spa
    {
        public bool Status { get; set; } = false;

        public Tratamiento tratamiento_Spa { get; set; } = new Tratamiento();
    }
}
