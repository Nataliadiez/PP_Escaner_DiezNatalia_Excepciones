using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un mapa, derivada de la clase Documento.
    /// </summary>
    public class Mapa : Documento
    {
        //Atributos
        int alto;
        int ancho;

        //Propiedades
        public int Alto
        {
            get => this.alto;
        }
        public int Ancho
        {
            get => this.ancho;
        }
        public int Superficie
        {
            get
            {
                return this.alto * this.ancho;
            }
        }

        // Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Mapa con los datos recibidos.
        /// A pesar de solicitar el parámetro numNormalizado, los mapas no tienen este dato, por eso su valor es de un string vacío.
        /// </summary>
        /// <param name="titulo">Título del mapa.</param>
        /// <param name="autor">Autor del mapa.</param>
        /// <param name="anio">Año de publicación del mapa.</param>
        /// <param name="numNormalizado">Num normalizado del mapa, pero los mapas no poseen este dato,por eso su valor es de un string vacío.</param>
        /// <param name="codebar">Código de barras del mapa.</param>
        /// <param name="ancho">Ancho del mapa.</param>
        /// <param name="alto">Alto del mapa.</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto) : base(titulo, autor, anio, "", codebar)
        {
            if (ancho <= 0)
            {
                throw ExcepcionPersonalizada.ParametroInvalido(nameof(ancho), ancho, this);
            }
            if (alto <= 0)
            {
                throw ExcepcionPersonalizada.ParametroInvalido(nameof(alto), alto, this);
            }
            this.ancho = ancho;
            this.alto = alto;
        }

        //Métodos
        /// <summary>
        /// <summary>
        /// Devuelve un string con los datos del Mapa instanciado (titulo, autor, año, barcode y agrega superficie).
        /// </summary>
        /// <returns>String con la información del Mapa instanciado.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Superficie: {this.alto} * {this.ancho} = {this.Superficie} cm2.\n");

            return sb.ToString();
        }

        /// <summary>
        /// Compara dos instancias de Mapa para determinar si son iguales.
        /// </summary>
        /// <param name="m1">Primer mapa a comparar.</param>
        /// <param name="m2">Segundo mapa a comparar.</param>
        /// <returns>true si los mapas son iguales; false en caso contrario.</returns>
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            bool barcode = m1.Barcode == m2.Barcode;
            bool autorYanio = (m1.Titulo == m2.Titulo) && (m1.Autor == m2.Autor);
            bool superficie = m1.Superficie == m2.Superficie;

            return barcode || (superficie && autorYanio);
        }

        /// <summary>
        /// Compara dos instancias de Mapa para determinar si son diferentes.
        /// </summary>
        /// <param name="m1">Primer mapa a comparar.</param>
        /// <param name="m2">Segundo mapa a comparar.</param>
        /// <returns>true si los mapas son diferentes; false en caso contrario.</returns>
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }

    }
}
