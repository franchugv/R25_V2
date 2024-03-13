using R25_V2;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Producto> ListaBar = new List<Producto>();

            

            ListaBar.Add(new Carne("Filetes", 3.45f, "Pechuga Pollo"));

            ListaBar[0].Cantidad = 10f;

            ListaBar.Add(new Bebida("Fino Baenita", 2.5f, "Montillita Moriles"));

            

            Console.WriteLine($"{ListaBar[0].ToString()}\n");
            
            Console.WriteLine(ListaBar[1].ToString());


        }
    }
}
