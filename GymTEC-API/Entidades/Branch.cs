namespace GymTEC_API.Entidades
{
    public class Branch
    {
        public string Name { get; set; } = string.Empty; //Atributo llave de la entidad Sucursal

        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public int max_Size { get; set; } = 0;
        public string opening_Date { get; set; }= string.Empty;
        public string schedule_Attention { get; set; } = string.Empty;
        //public Empleado empleado_Admin { get; set; } = new Empleado(); //Conexión con la entidad Empleado
        /*
        public Spa spa_Branch { get; set; } = new Spa(); //Conexión con la entidad Spa
        public Shop shop_Branch { get; set; } = new Shop(); //Conexión con la entidad Tienda
        public Inventory inventory_Branch { get; set; } = new Inventory(); //Conexión con la entidad Inventario
        public List<BranchPhone> phone_List { get; set; } = new List<BranchPhone>();
        public List<Service> services = new List<Service>(); //Conexión de sucursal con servicio
        */
    }
}
