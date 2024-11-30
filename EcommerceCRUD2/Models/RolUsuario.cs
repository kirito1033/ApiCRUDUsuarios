using System;
using System.Collections.Generic;

namespace EcommerceCRUD2.Models
{
    /// <summary>
    /// Tabla para la asignacion de roles de usuarios
    /// </summary>
    public partial class RolUsuario
    {
        /// <summary>
        /// Llave foranea de la tabla rol
        /// </summary>
        public sbyte RolIdRol { get; set; }
        /// <summary>
        /// Llave foranea de la tabla usuario
        /// </summary>
        public int UsuarioIdUsuario { get; set; }
        /// <summary>
        /// Campo destinado para la activacion o desactivacion del rol de un usuario
        /// </summary>
        public ulong Estado { get; set; }

        public virtual Rol RolIdRolNavigation { get; set; } = null!;
        public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
    }
}
