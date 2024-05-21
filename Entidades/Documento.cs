using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta que representa un documento.
    /// No puede ser instanciada.
    /// </summary>
    public abstract class Documento
    {
        //Atributos
        int anio;
        string autor;
        string barcode;
        Paso estado;
        string numNormalizado;
        string titulo;

        //Enumerados
        /// <summary>
        /// Enumeración que representa los diferentes estados por los que puede pasar un documento.
        /// </summary>
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        //Propiedades
        public int Anio
        {
            get => this.anio;
        }
        public string Autor
        {
            get => this.autor;
        }
        public string Barcode
        {
            get => this.barcode;
        }
        public Paso Estado
        {
            get => this.estado;
        }
        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }
        public string Titulo
        {
            get => this.titulo;
        }

        //Constructor
        // Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Documento con los datos recibidos.
        /// </summary>
        /// <param name="titulo">Título del documento.</param>
        /// <param name="autor">Autor del documento.</param>
        /// <param name="anio">Año de publicación del documento.</param>
        /// <param name="numNormalizado">Número normalizado del documento.</param>
        /// <param name="barcode">Código de barras del documento.</param>
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw ExcepcionPersonalizada.ParametroInvalido(nameof(titulo), titulo, this);
            }
            if (string.IsNullOrWhiteSpace(autor))
            {
                throw ExcepcionPersonalizada.ParametroInvalido(nameof(autor), autor, this);
            }
            if (anio <= 0)
            {
                throw ExcepcionPersonalizada.ParametroInvalido(nameof(anio), anio, this);
            }
            if (string.IsNullOrWhiteSpace(barcode))
            {
                throw ExcepcionPersonalizada.ParametroInvalido(nameof(barcode), barcode, this);
            }
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        //Métodos
        /// <summary>
        /// Devuelve un string con los datos del objeto (titulo, autor, año y barcode).
        /// </summary>
        /// <returns>String con la información del objeto.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Titulo: {this.titulo}");
            sb.AppendLine($"Autor: {this.autor}");
            sb.AppendLine($"Año: {this.anio}");
            sb.AppendLine($"Cód. de barras: {this.barcode}");

            return sb.ToString();
        }

        /// <summary>
        /// Avanza el estado del documento al siguiente estado en la enumeración Paso.
        /// </summary>
        /// <returns>true si el estado fue avanzado con éxito; false si el documento ya estaba en el estado Terminado.</returns>
        public bool AvanzarEstado()
        {
            bool resultado = true;
            //cambiar por ++
            if (this.estado == Paso.Terminado)
            {
                resultado = false;
            }
            else
            {
                this.estado++;
            }
            return resultado;
        }


    }
}
