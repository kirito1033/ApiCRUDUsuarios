namespace EcommerceCRUD2.Models
{
    public class AddUpdateUsuario
    {
        /// <summary>
        /// Primer nombre del usuario
        /// </summary>
        public string Nom1 { get; set; } = string.Empty;

        /// <summary>
        /// Segundo nombre del usuario
        /// </summary>
        public string? Nom2 { get; set; }

        /// <summary>
        /// Primer apellido del usuario
        /// </summary>
        public string Apellido1 { get; set; } = string.Empty;

        /// <summary>
        /// Segundo apellido del usuario
        /// </summary>
        public string? Apellido2 { get; set; }

        /// <summary>
        /// Numero de documento del usuario
        /// </summary>
        public long Doc { get; set; }

        /// <summary>
        /// Correo electrónico del usuario
        /// </summary>
        public string Correo { get; set; } = string.Empty;

        /// <summary>
        /// Numero telefónico del usuario
        /// </summary>
        public long Tel1 { get; set; }

        /// <summary>
        /// Segundo número de teléfono del usuario
        /// </summary>
        public long? Tel2 { get; set; }

        /// <summary>
        /// Dirección del usuario
        /// </summary>
        public string Direccion { get; set; } = string.Empty;

        /// <summary>
        /// Nombre de usuario único para ingresar al sistema
        /// </summary>
        public string Usuario1 { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña para el acceso al sistema
        /// </summary>
        public string Password { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        /// <summary>
        /// Id del tipo de documento
        /// </summary>
        public sbyte TipoDocId { get; set; }

        /// <summary>
        /// Id de la ciudad
        /// </summary>
        public short CiudadId { get; set; }
    }
}
