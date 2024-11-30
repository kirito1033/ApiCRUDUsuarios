using System;
using System.Collections.Generic;

namespace EcommerceCRUD2.Models
{
    /// <summary>
    /// Espacio destinado para la gestion de roles
    /// </summary>
    public partial class Rol
    {
        public Rol()
        {
            RolUsuarios = new HashSet<RolUsuario>();
        }

        /// <summary>
        /// Identificador unico del rol
        /// </summary>
        public sbyte Id { get; set; }
        /// <summary>
        /// Identifica el rol del usuario
        /// </summary>
        public string Nom { get; set; } = null!;
        /// <summary>
        /// Espacio destinado para indicar los permisos y descripcion general de cada rol
        /// </summary>
        public string? Descripcion { get; set; }

        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
