namespace console_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //** Cadena de conexión a la BD (Se envía por parámetro a los Handle)
            string connectionString = "Data Source=DESKTOP-B08FRCB;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            //** Ejercicio #1: Traer Usuario (recibe un int)
            Usuario usuario = UsuarioHandle.getUsuario(connectionString, 2);

            Console.WriteLine("Ejercicio #1 -->");
            Console.WriteLine($"ID del Usuario: {usuario.Id}");
            Console.WriteLine($"Apellido del Usuario: {usuario.Apellido}");
            Console.WriteLine($"Mail del Usuario: {usuario.Mail}");
            Console.WriteLine("************************************************************************************************************************************************************************");



            //** Ejercicio #2: Traer Productos (recibe un id de usuario y devuelve una lista con todos los productos cargado por ese usuario)
            List<Producto> productos = ProductoHandle.getProductosXUsuario(connectionString, 2);

            Console.WriteLine("Ejercicio #2 -->");
            foreach (var item in productos)
            {
                Console.WriteLine($"ID: {item.Id} \t\t Descripción: {item.Descripciones} \t\t Costo: {item.Costo} \t\t Precio de Venta: {item.PrecioVenta} \t\t ID Usuario: {item.IdUsuario}");
            }
            Console.WriteLine("************************************************************************************************************************************************************************");



            //** Ejercicio #3: Traer ProductosVendidos (recibe un id de usuario y devuelve una lista de los productos vendidos por ese usuario)
            List<ProductoVenta> productosVenta = ProductoVentaHandle.getProductosVendidosXUsuario(connectionString, 2);

            Console.WriteLine("Ejercicio #3 -->");
            foreach (var item in productosVenta)
            {
                Console.WriteLine($"ID: {item.Id} \t\t Stock: {item.Stock} \t\t ID Producto: {item.IdProducto} \t\t ID Venta: {item.IdVenta}");
            }
            Console.WriteLine("************************************************************************************************************************************************************************");



            //** Ejercicio #4: Traer Ventas (recibe el id de usuario y devuelve una lista de ventas realizadas por ese usuario) 
            List<Venta> ventas = VentaHandle.getVentasXUsuario(connectionString, 2);

            Console.WriteLine("Ejercicio #4 -->");
            foreach (var item in ventas)
            {
                Console.WriteLine($"ID: {item.Id} \t\t Comentarios: {item.Comentarios} \t\t\t\t\t ID Usuario: {item.IdUsuario}");
            }
            Console.WriteLine("************************************************************************************************************************************************************************");



            //** Ejercicio #5: Inicio de sesión (recibe un usuario y contraseña y devuelve un objeto usuario) 
            Usuario usuario2 = UsuarioHandle.Login(connectionString, 3, "SoyPedroGonzalez");

            Console.WriteLine("Ejercicio #5 -->");
            Console.WriteLine($"ID del Usuario: {usuario2.Id}");
            Console.WriteLine($"Nombre del Usuario: {usuario2.Nombre}");
            Console.WriteLine($"Apellido del Usuario: {usuario2.Apellido}");
            Console.WriteLine($"Contraseña del Usuario: {usuario2.Contrasena}");
            Console.WriteLine($"Mail del Usuario: {usuario2.Mail}");
            Console.WriteLine("************************************************************************************************************************************************************************");
        }
    }
}