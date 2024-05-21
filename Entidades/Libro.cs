using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un libro, derivada de la clase Documento.
    /// </summary>
    public class Libro : Documento
    {
        //Atributos
        int numPaginas;

        //Propiedades
        public string ISBN
        {
            get => this.NumNormalizado;
        }
        public int NumPaginas
        {
            get => this.numPaginas;
        }

        //Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Libro con los datos recibidos.
        /// </summary>
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor del libro.</param>
        /// <param name="anio">Año de publicación del libro.</param>
        /// <param name="numNormalizado">Número normalizado (ISBN) del libro.</param>
        /// <param name="codebar">Código de barras del libro.</param>
        /// <param name="numPaginas">Número de páginas del libro.</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas) : base(titulo, autor, anio, numNormalizado, codebar)
        {
            if (string.IsNullOrWhiteSpace(numNormalizado))
            {
                throw ExcepcionPersonalizada.ParametroInvalido(nameof(titulo), titulo, this);
            }
            if (numPaginas <= 0)
            {
                throw ExcepcionPersonalizada.ParametroInvalido(nameof(numPaginas), numPaginas, this);
            }
            this.numPaginas = numPaginas;
        }

        //Métodos
        /// <summary>
        /// <summary>
        /// Devuelve un string con los datos del Libro instanciado (titulo, autor, año, barcode y agrega número de páginas e ISBN).
        /// </summary>
        /// <returns>String con la información del Libro instanciado.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string stringBase = base.ToString();
            string[] arrayDePartes = stringBase.Split('\n');
            for (int i = 0; i < arrayDePartes.Length - 2; i++)
            {
                sb.AppendLine(arrayDePartes[i]);
            }
            sb.AppendLine($"ISBN: {this.NumNormalizado}");
            sb.AppendLine(arrayDePartes[arrayDePartes.Length - 2]);
            sb.AppendLine($"Número de páginas: {this.NumPaginas}.\n");

            return sb.ToString();
        }

        /// <summary>
        /// Compara dos instancias de Libro para determinar si son iguales:
        /// * Tenga el mismo barcode o
        /// * tenga el mismo ISBN o
        /// * tenga el mismo título y el mismo autor.
        /// </summary>
        /// <param name="l1">Primer libro a comparar.</param>
        /// <param name="l2">Segundo libro a comparar.</param>
        /// <returns>true si los libros son iguales; false en caso contrario.</returns>
        public static bool operator ==(Libro l1, Libro l2)
        {
            bool tituloYAutor = (l1.Titulo == l2.Titulo) && (l1.Autor == l2.Autor);
            bool barcode = l1.Barcode == l2.Barcode;
            bool ISBN = l1.ISBN == l2.ISBN;
            return tituloYAutor || barcode || ISBN;
        }

        /// <summary>
        /// Compara dos instancias de Libro para determinar si son diferentes.
        /// </summary>
        /// <param name="l1">Primer libro a comparar.</param>
        /// <param name="l2">Segundo libro a comparar.</param>
        /// <returns>true si los libros son diferentes; false en caso contrario.</returns>
        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

    }
}
