using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proyecto con excepciones");

            Escaner escanerLibros = new Escaner("Exo", Escaner.TipoDoc.libro);
            Escaner escanerMapas = new Escaner("Samsung", Escaner.TipoDoc.mapa);

            Mapa mapa2 = new Mapa("Argentina", "Miguel", 2010, "", "23842834", 42, 10);
            Libro libro2 = new Libro("La reina en el palacio de las corrientes de aire", "Stieg Larsson", 2007, "654321351", "15423489", 800);

            bool agregarDocumento = false;

            //MANEJO DE EXCEPCIONES
            //CONSTRUCTORES CORRECTOS
            //Libro con constructor correcto
            try
            {
                Libro libro1 = new Libro("La chica que soñaba con una cerilla y un bidón e Gasolina", "Stieg Larsson", 2004, "654321351", "1154245410115", 600);
                Console.WriteLine($"Creación de {libro1.GetType().Name} {libro1.Titulo} exitosa!\n");
            }
            catch (ExcepcionPersonalizada e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            //Mapa con constructor correcto
            try
            {
                Mapa mapa1 = new Mapa("awdawd", "Miguel", 2010, "", "23842834", 42, 10);
                Console.WriteLine($"Creación de {mapa1.GetType().Name} {mapa1.Titulo} exitosa!\n");
            }
            catch (ExcepcionPersonalizada e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            //Escaner con constructor correcto
            try
            {
                Escaner escanerLibros2 = new Escaner("Sony", Escaner.TipoDoc.libro);
                Console.WriteLine($"Creación de escaner de {escanerLibros2.GetType().Name} exitosa!\n");
            }
            catch (ExcepcionPersonalizada e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            //AGREGADO DE DOCUMENTOS LIBRO O MAPA A ESCANER CORRECTOS
            //Agregado de libro a escaner correcto
            try
            {
                agregarDocumento = escanerLibros + libro2;
                Console.WriteLine($"Carga de {libro2.GetType().Name} '{libro2.Titulo}' en el escaner de tipo {escanerLibros.Tipo} exitosa.\n");
            }
            catch (ExcepcionPersonalizada e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            //Agregado de mapa a escaner correcto
            try
            {
                agregarDocumento = escanerMapas + mapa2;
                Console.WriteLine($"Carga de {mapa2.GetType().Name} '{mapa2.Titulo}' en el escaner de tipo {escanerMapas.Tipo} exitosa.\n");
            }
            catch (ExcepcionPersonalizada e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            Console.ReadKey();

        }
    }
}
