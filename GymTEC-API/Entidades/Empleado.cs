namespace GymTEC_API.Entidades
{
    public class Empleado
    {

        public string Cedula_Empleado { get; set; } = string.Empty; //Atributo llave de la entidad Empleado
        
        public string Provincia { get; set; } = string.Empty;
        public string Distrito { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public string Salario { get; set; } = string.Empty;
        public string P_Nombre { get; set; } = string.Empty;
        public string S_Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string Apellido2 { get; set; } = string.Empty;

        //public Planilla planilla_Empleado { get; set; } = new Planilla();
        //public List<Planilla> Planilla_Empleados_List { get; set; } = new List<Planilla>();

        //public Puesto puesto_Empleado { get; set; } = new Puesto();
        //public List<Puesto> puesto_Empleado_List { get; set; } = new List<Puesto>();



    }
}
