using System;
using System.Collections.Generic;

namespace EcommerceCRUD2.Models
{
    /// <summary>
    /// Identifica el departamento donde se encuentra el cliente a partir de la ciudad
    /// </summary>
    public partial class Departamento
    {
        public Departamento()
        {
            Ciudads = new HashSet<Ciudad>();
        }

        /// <summary>
        /// Identificador unico para los departamentos
        /// </summary>
        public sbyte Id { get; set; }
        /// <summary>
        /// Nombre del departamento
        /// </summary>
        public string Nom { get; set; } = null!;

        public virtual ICollection<Ciudad> Ciudads { get; set; }
    }
}
