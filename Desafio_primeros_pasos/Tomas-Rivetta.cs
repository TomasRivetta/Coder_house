namespace PrimerosPasos
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Usuario
    {
        public int id;

        private string nombre;

        private string apellido;

        private string nombreUsuario;

        private int contrasenia;

        private string mail;
    }

    class Producto
    {
        public int id;

        private string descripcion;

        private double costo;

        private double precioVenta;

        public int stock;

        private int idUsuario;
    }

    class ProductoVendido
    {
        private int id;

        private int idProducto;

        private int stock;

        public int idVenta;
    }

    class Venta
    {
        private int id;

        private string comentarios;
    }
}