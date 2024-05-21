using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa una excepción personalizada.
    /// </summary>
    public class ExcepcionPersonalizada : Exception
    {
        /// <summary>
        /// Constructor de Excepcion personalizada que recibe un mensaje como parámetro
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        public ExcepcionPersonalizada(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Crea una excepción personalizada indicando que un parámetro string es inválido o está vacío.
        /// </summary>
        /// <param name="nombreCampo">Nombre del campo que es inválido o está vacío.</param>
        /// <param name="campo">Valor del campo que es inválido o está vacío.</param>
        /// <returns>Una nueva instancia de <see cref="ExcepcionPersonalizada"/>.</returns>
        public static ExcepcionPersonalizada ParametroInvalido(string nombreCampo, string campo, Documento d)
        {
            return new ExcepcionPersonalizada($"El parámetro '{nombreCampo}' del objeto {d.GetType().Name} tiene un valor inválido o está vacío\nValor ingresado:  '{campo}'.");
        }

        /// <summary>
        /// Crea una excepción personalizada indicando que un parámetro int es inválido o está vacío.
        /// </summary>
        /// <param name="nombreCampo">Nombre del campo que es inválido o está vacío.</param>
        /// <param name="campo">Valor del campo que es inválido o está vacío.</param>
        /// <returns>Una nueva instancia de <see cref="ExcepcionPersonalizada"/>.</returns>
        public static ExcepcionPersonalizada ParametroInvalido(string nombreCampo, int campo, Documento d)
        {
            return new ExcepcionPersonalizada($"El parámetro '{nombreCampo}' del objeto {d.GetType().Name} tiene un valor inválido o está vacío.\nValor ingresado: {campo}'.");
        }

        /// <summary>
        /// Crea una excepción personalizada indicando que un documento es incompatible con un escáner.
        /// </summary>
        /// <param name="d">El documento que es incompatible.</param>
        /// <param name="e">El escáner con el que el documento es incompatible.</param>
        /// <returns>Una nueva instancia de <see cref="ExcepcionPersonalizada"/>.</returns>
        public static ExcepcionPersonalizada TiposDeObjetosIncompatibles(Documento d, Escaner e)
        {
            return new ExcepcionPersonalizada($"El documento de tipo {d.GetType().Name} es incompatible con el escaner de tipo {e.Tipo}");
        }

        public static ExcepcionPersonalizada ParametroInvalidoEscaner(Escaner e, string marca)
        {
            return new ExcepcionPersonalizada($"El escaner de tipo {e.Tipo} recibió una marca inválida o vacía. Dato ingresado: {marca}");
        }
    }
}

