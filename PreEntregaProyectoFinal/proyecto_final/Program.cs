using Proyecto_final.ADO.NET;
using Proyecto_final.modelos;

namespace Proyecto_final
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu de Opciones: ");
            bool menu = true;

            Console.WriteLine("1-Traer Usuario");
            Console.WriteLine("2-Traer Productos");
            Console.WriteLine("3-Traer Productos Vendidos");
            Console.WriteLine("4-Traer Ventas");
            Console.WriteLine("5-Inicio de Sesion");
            Console.WriteLine("6-Terminar Programa");
            Console.WriteLine();
            Console.WriteLine("Ingrese una opcion: ");
            int opc = Convert.ToInt32(Console.ReadLine());

            while (menu == true)
            {

                if (opc == 1)
                {
                    //PARA SABER LOS DATOS DE UN USUARIO INGRESANDO SU NOMBRE

                    UsuarioHandler usuarioHandler = new UsuarioHandler();
                    Console.WriteLine("Ingrese el Nombre del Usuario, para saber sus DATOS: ");
                    string nombreIngresado = Convert.ToString(Console.ReadLine());

                    List<Usuario> Usuario = usuarioHandler.ObtenerUsuario(nombreIngresado);
                    Console.WriteLine("---------------------------------");
                    foreach (var usuario in Usuario)
                    {

                        Console.WriteLine("Codigo = " + usuario.Id);
                        Console.WriteLine("Nombre = " + usuario.Nombre);
                        Console.WriteLine("Apellido = " + usuario.Apellido);
                        Console.WriteLine("Nombre del Usuario = " + usuario.NombreUsuario);
                        Console.WriteLine("Contraseña = " + usuario.Contrasenia);
                        Console.WriteLine("Mail = " + usuario.Mail);

                        Console.WriteLine("---------------------------------");
                    }

                }

                else if (opc == 2)
                {
                    //PARA SABER QUE PRODUCTOS CARGO EL USUARIO CON TAL ID

                    ProductoHandler productosIdHandler = new ProductoHandler();
                    Console.WriteLine("Ingrese el ID USUARIO, para saber que productos CARGO: ");
                    int idUsuario = Convert.ToInt32(Console.ReadLine());

                    List<Producto> Productos = productosIdHandler.DevolverProductosConIdusuario(idUsuario);
                    Console.WriteLine("---------------------------------");
                    foreach (var produc in Productos)
                    {
                        Console.WriteLine("Codigo = " + produc.Id);
                        Console.WriteLine("descripcion = " + produc.Descripcion);
                        Console.WriteLine("precioVenta = " + produc.PrecioVenta);
                        Console.WriteLine("Stock = " + produc.Stock);
                        Console.WriteLine("IdUsuario = " + produc.IdUsuario);

                        Console.WriteLine("---------------------------------");
                    }
                }

                else if (opc == 3)
                {
                    //SABER QUE PRODUCTOS VENDIO UN USARIO CON SU ID VENTA

                    ProductosVendidosHandler ProductosVendidosHandler = new ProductosVendidosHandler();
                    Console.WriteLine("Ingrese el ID USUARIO, para saber que productos VENDIO el usuario particular: ");
                    int idVenta = Convert.ToInt32(Console.ReadLine());

                    List<ProductoVendido> ProductoVenta = ProductosVendidosHandler.DevolverProductosVendidos(idVenta);
                    Console.WriteLine("---------------------------------");
                    foreach (var producto in ProductoVenta)
                    {
                        Console.WriteLine("Codigo = " + producto.id);
                        Console.WriteLine("Stock = " + producto.stock);
                        Console.WriteLine("Id Producto = " + producto.idProducto);
                        Console.WriteLine("Id Venta = " + producto.idVenta);

                        Console.WriteLine("---------------------------------");
                    }
                }

                else if (opc == 4)
                {
                    //TRAER TODAS LAS VENTAS ASIGNADAS A UN USUARIO EN PARTICULAR

                    VentasHandler listaVenta = new VentasHandler();
                    Console.WriteLine("Ingrese el ID USUARIO, para saber todas las ventas del usuario particular: ");
                    int idVenta = Convert.ToInt32(Console.ReadLine());

                    List<Venta> Venta = listaVenta.DevolverProductosVendidos(idVenta);
                    Console.WriteLine("---------------------------------");
                    foreach (var venta in Venta)
                    {
                        Console.WriteLine("Codigo = " + venta.id);
                        Console.WriteLine("Comentarios = " + venta.comentarios);
                        Console.WriteLine("Id Usuario = " + venta.idUsuario);

                        Console.WriteLine("---------------------------------");
                    }

                }
                else if (opc == 5)
                {
                    //INICIO DE SESION

                    LoginHandler loginHandler = new LoginHandler();

                    Console.WriteLine();
                    Console.WriteLine("INICIO DE SESION...");
                    Console.WriteLine();

                    Console.WriteLine("Ingrese el Nombre: ");
                    string nombreUsuario = Convert.ToString(Console.ReadLine());

                    Console.WriteLine("Ingrese su contraseña: ");
                    string contraseña = Convert.ToString(Console.ReadLine());

                    List<Usuario> Usuario = loginHandler.Login(nombreUsuario, contraseña);
                    Console.WriteLine("---------------------------------");
                    foreach (var usuario in Usuario)
                    {

                        Console.WriteLine("Codigo = " + usuario.Id);
                        Console.WriteLine("Nombre = " + usuario.Nombre);
                        Console.WriteLine("Apellido = " + usuario.Apellido);
                        Console.WriteLine("Nombre del Usuario = " + usuario.NombreUsuario);
                        Console.WriteLine("Contraseña = " + usuario.Contrasenia);
                        Console.WriteLine("Mail = " + usuario.Mail);

                        Console.WriteLine("---------------------------------");
                    }

                }
                else if (opc == 6)
                {
                    Console.WriteLine();
                    Console.WriteLine("Muchas gracias por usar el programa");
                    break;
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Ingreso una opcion que no esta en el menu...");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Ingrese otra opcion: ");
                opc = Convert.ToInt32(Console.ReadLine());

            }
        }
    }
}