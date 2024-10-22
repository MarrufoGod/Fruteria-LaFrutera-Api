namespace Api_Innovatech.Model
{
    public class productos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public string origen { get; set; }
        public string descripcion { get; set; }
        public int proveedor_id { get; set; }
    }
}
