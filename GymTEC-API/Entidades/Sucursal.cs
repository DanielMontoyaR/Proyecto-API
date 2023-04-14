namespace GymTEC_API.Entidades
{
    public class Sucursal
    {
        public string Nombre { get; set; } = string.Empty; //Atributo llave de la entidad Sucursal

        public string Provincia { get; set; } = string.Empty;
        public string Distrito { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public int capacidad_Max { get; set; } = 0;
        public string fecha_Apertura { get; set; }= string.Empty;
        public string horario_Atencion { get; set; } = string.Empty;
        //public Empleado empleado_Admin { get; set; } = new Empleado(); //Conexión con la entidad Empleado
        public Spa spa_Sucursal { get; set; } = new Spa(); //Conexión con la entidad Spa
        public Tienda tienda_Sucursal { get; set; } = new Tienda(); //Conexión con la entidad Tienda
        public Inventario inventario_Sucursal { get; set; } = new Inventario(); //Conexión con la entidad Inventario
        public List<TelefonoSucursal> telefonos_List { get; set; } = new List<TelefonoSucursal>();
        public List<Servicio> servicios = new List<Servicio>(); //Conexión de sucursal con servicio


    }
}
