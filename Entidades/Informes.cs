using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        /// <summary>
        /// Muestra los documentos de un escáner que se encuentran en un estado específico ((distribuido, en escaner, etc.).
        /// </summary>
        /// <param name="e">El escaner que contiene los documentos.</param>
        /// <param name="estado">El estado en el que deben estar los documentos para ser mostrados (distribuido, en escaner, etc.).</param>
        /// <param name="extension">Guarda el número de páginas si el estado es TipoDoc.Libro, o la superficie si es TipoDoc.Mapa).</param>
        /// <param name="cantidad">Guarda la cantidad total de documentos en el estado especificado.</param>
        /// <param name="resumen">Guarda un resumen de la información de los documentos en el estado especificado.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";

            foreach (Documento d in e.ListaDocumentos)
            {
                if (d.Estado == estado)
                {
                    if ((e.Tipo == Escaner.TipoDoc.libro))
                    {
                        Libro libro = (Libro)d;
                        extension += libro.NumPaginas;
                    }
                    else if ((e.Tipo == Escaner.TipoDoc.mapa))
                    {
                        Mapa mapa = (Mapa)d;
                        extension += mapa.Superficie;
                    }
                    resumen += d.ToString();
                    cantidad++;
                }
            }
        }

        /// <summary>
        /// Muestra los documentos de un escáner que se encuentran en estado distribuido.
        /// </summary>
        /// <param name="e">El escáner que contiene los documentos.</param>
        /// <param name="extension">Guarda el número de páginas si el estado es TipoDoc.Libro, o la superficie si es TipoDoc.Mapa).</param>
        /// <param name="cantidad">Guarda la cantidad total de documentos en estado distribuido.</param>
        /// <param name="resumen">Guarda un resumen de la información de los documentos en estado distribuido.</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            Informes.MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos de un escáner que se encuentran en estado de escaneo.
        /// </summary>
        /// <param name="e">El escáner que contiene los documentos.</param>
        /// <param name="extension">Guarda el número de páginas si el estado es TipoDoc.Libro, o la superficie si es TipoDoc.Mapa).</param>
        /// <param name="cantidad">Guarda la cantidad total de documentos en estado en escaner.</param>
        /// <param name="resumen">Guarda un resumen de la información de los documentos en estado en escaner.</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            Informes.MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos de un escáner que se encuentran en estado de revisión.
        /// </summary>
        /// <param name="e">El escáner que contiene los documentos.</param>
        /// <param name="extension">Guarda el número de páginas si el estado es TipoDoc.Libro, o la superficie si es TipoDoc.Mapa).</param>
        /// <param name="cantidad">Guarda la cantidad total de documentos en estado en revision.</param>
        /// <param name="resumen">Guarda un resumen de la información de los documentos en estado en revision.</param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            Informes.MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos de un escáner que se encuentran en estado terminado.
        /// </summary>
        /// <param name="e">El escáner que contiene los documentos.</param>
        /// <param name="extension">Guarda el número de páginas si el estado es TipoDoc.Libro, o la superficie si es TipoDoc.Mapa).</param>
        /// <param name="cantidad">Guarda la cantidad total de documentos en estado terminado.</param>
        /// <param name="resumen">Guarda un resumen de la información de los documentos en estado terminado.</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            Informes.MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}
