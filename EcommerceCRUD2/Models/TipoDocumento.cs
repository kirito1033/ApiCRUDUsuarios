using System;
using System.Collections.Generic;

namespace EcommerceCRUD2.Models
{
    /// <summary>
    /// Tabla para la gestion del tipo de documento
    /// </summary>
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Usuarios = new HashSet<Usuario>();
        }

        /// <summary>
        /// Identificador unico del tipo de documento
        /// </summary>
        public sbyte Id { get; set; }
        /// <summary>
        /// Nombre del tipo de documento
        /// </summary>
        public string Nom { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
