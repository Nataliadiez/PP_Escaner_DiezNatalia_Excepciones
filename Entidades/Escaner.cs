using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un escáner que puede manejar documentos de tipo libro o mapa.
    /// </summary>
    public class Escaner
    {
        //Atributos
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        //Enumerados
        /// <summary>
        /// Enumeración que define los departamentos donde puede estar ubicado el escáner.
        /// </summary>
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        /// <summary>
        /// Enumeración que define los tipos de documentos que puede manejar el escáner.
        /// </summary>
        public enum TipoDoc
        {
            libro,
            mapa
        }

        //Propiedades
        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }
        public Departamento Locacion
        {
            get => this.locacion;
        }
        public string Marca
        {
            get => this.marca;
        }
        public TipoDoc Tipo
        {
            get => this.tipo;
        }

        // Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Escaner con la marca y tipo de documento recibidos.
        /// </summary>
        /// <param name="marca">Marca del escáner.</param>
        /// <param name="tipo">Tipo de documento que maneja el escáner.</param>
        public Escaner(string marca, TipoDoc tipo)
        {
            if (string.IsNullOrWhiteSpace(marca))
            {
                throw ExcepcionPersonalizada.ParametroInvalidoEscaner(this, marca);
            }
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            switch (tipo)
            {
                case TipoDoc.mapa:
                    this.locacion = Departamento.mapoteca;
                    break;
                case TipoDoc.libro:
                    this.locacion = Departamento.procesosTecnicos;
                    break;
                default:
                    this.locacion = Departamento.nulo;
                    break;
            }
        }

        // Métodos
        /// <summary>
        /// Cambia el estado de un documento específico en la lista de documentos del escáner (distribuido, en escaner, etc.).
        /// </summary>
        /// <param name="d">Documento cuyo estado se desea cambiar.</param>
        /// <returns>True si el estado del documento se cambia con éxito; False en caso contrario.</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            bool resultado = false;
            if ((this.tipo == TipoDoc.mapa && d is Libro) || (this.tipo == TipoDoc.libro && d is Mapa))
            {
                throw ExcepcionPersonalizada.TiposDeObjetosIncompatibles(d, this);
            }
            foreach (Documento doc in this.listaDocumentos)
            {
                if (((this.locacion == Departamento.procesosTecnicos) && ((Libro)doc == (Libro)d))
                    || ((this.locacion == Departamento.mapoteca) && ((Mapa)doc == (Mapa)d)))
                {
                    resultado = doc.AvanzarEstado();
                    break;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Compara si un documento específico está en la lista de documentos del escáner.
        /// </summary>
        /// <param name="e">Escáner a comparar.</param>
        /// <param name="d">Documento a comparar.</param>
        /// <returns>True si el documento está en la lista; de lo contrario, false.</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            bool resultado = false;
            foreach (Documento doc in e.listaDocumentos)
            {
                if (((d is Libro && doc is Libro) && ((Libro)doc == (Libro)d)) || ((d is Mapa && doc is Mapa) && ((Mapa)doc == (Mapa)d)))
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Compara si un documento específico no está en la lista de documentos del escáner.
        /// </summary>
        /// <param name="e">Escáner a comparar.</param>
        /// <param name="d">Documento a comparar.</param>
        /// <returns>True si el documento no está en la lista; de lo contrario, false.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        /// <summary>
        /// Agrega un documento a la lista de documentos del escáner si no está presente y su estado es Inicio.
        /// </summary>
        /// <param name="e">Escáner al que se agregará el documento.</param>
        /// <param name="d">Documento a agregar.</param>
        /// <returns>True si el documento se agrega con éxito; de lo contrario, false.</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool resultado = false;
            if ((e.Tipo == TipoDoc.mapa && d is Libro) || (e.Tipo == TipoDoc.libro && d is Mapa))
            {
                throw ExcepcionPersonalizada.TiposDeObjetosIncompatibles(d, e);
            }
            else if ((e != d) && (d.Estado == Documento.Paso.Inicio))
            {
                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
                resultado = true;
            }
            return resultado;
        }

    }
}
