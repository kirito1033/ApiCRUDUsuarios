using System;
using System.Collections.Generic;

namespace EcommerceCRUD2.Models
{
    /// <summary>
    /// Identifica la ciudad donde se encuentra el cliente
    /// </summary>
    public partial class Ciudad
    {
        public Ciudad()
        {
            Usuarios = new HashSet<Usuario>();
        }

        /// <summary>
        /// Identificador unico para las ciudades
        /// </summary>
        public short Id { get; set; }
        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        public string Nom { get; set; } = null!;
        /// <summary>
        /// Llave foranea de la tabla de departamento
        /// </summary>
        public sbyte Departamentoid { get; set; }

        public virtual Departamento Departamento { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
