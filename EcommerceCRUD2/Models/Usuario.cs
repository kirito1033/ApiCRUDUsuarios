using System;
using System.Collections.Generic;

namespace EcommerceCRUD2.Models
{
    /// <summary>
    /// En esta tabla se gestionara la informacion de los usuarios
    /// </summary>
    public partial class Usuario
    {
        public Usuario()
        {
            RolUsuarios = new HashSet<RolUsuario>();
        }

        /// <summary>
        /// Llave primaria que identifica de forma única al usuario
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// primer nombre del usuario
        /// </summary>
        public string Nom1 { get; set; } = null!;
        /// <summary>
        /// Segundo nombre del usuario
        /// </summary>
        public string? Nom2 { get; set; }
        /// <summary>
        /// Primer apellido del usuario
        /// </summary>
        public string Apellido1 { get; set; } = null!;
        /// <summary>
        /// segundo apellido del usuario
        /// </summary>
        public string? Apellido2 { get; set; }
        /// <summary>
        /// Numero de documento del usuario.
        /// </summary>
        public long Doc { get; set; }
        /// <summary>
        /// Correo electronico del usuario
        /// </summary>
        public string Correo { get; set; } = null!;
        /// <summary>
        /// Numero telefonico del usuario
        /// </summary>
        public long Tel1 { get; set; }
        /// <summary>
        /// Segundo numero de telefono del usuario
        /// </summary>
        public long? Tel2 { get; set; }
        /// <summary>
        /// Direcion donde se encuentra el usuario
        /// </summary>
        public string Direccion { get; set; } = null!;
        /// <summary>
        /// Nombre unico para ingresar al sistema 
        /// </summary>
        public string Usuario1 { get; set; } = null!;
        /// <summary>
        /// Palabra secreta que permite el acceso a la plataforma
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// Llave foranea de la tabla tipo de documento
        /// </summary>
        public sbyte TipoDocId { get; set; }
        /// <summary>
        /// Llave foranea de la tabla ciudad
        /// </summary>
        public short CiudadId { get; set; }

        public bool IsActive { get; set; }
        public virtual Ciudad Ciudad { get; set; } = null!;
        public virtual TipoDocumento TipoDoc { get; set; } = null!;
        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
