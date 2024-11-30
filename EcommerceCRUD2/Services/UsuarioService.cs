using EcommerceCRUD2.Models;
using EcommerceCRUD2.Services;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCRUD2.Services
{

    public class UsuarioService : IUsuarioService
    {
        private readonly ecommercetechdbContext _context;

        public UsuarioService(ecommercetechdbContext context)
        {
            _context = context;
        }

        // Método asincrónico para agregar un usuario
        public Usuario CreateUsuarioAsync(AddUpdateUsuario usuarioData)
        {
            var newUsuario = new Usuario
            {
                Nom1 = usuarioData.Nom1,
                Nom2 = usuarioData.Nom2,
                Apellido1 = usuarioData.Apellido1,
                Apellido2 = usuarioData.Apellido2,
                Doc = usuarioData.Doc,
                Correo = usuarioData.Correo,
                Tel1 = usuarioData.Tel1,
                Tel2 = usuarioData.Tel2,
                Direccion = usuarioData.Direccion,
                Usuario1 = usuarioData.Usuario1,
                Password = usuarioData.Password,
                IsActive = usuarioData.IsActive, 
                TipoDocId = usuarioData.TipoDocId,
                CiudadId = usuarioData.CiudadId,
            };

            _context.Usuarios.Add(newUsuario);
            _context.SaveChanges();  

            return newUsuario;
        }

        // Método asincrónico para actualizar un usuario
        public Usuario? UpdateUsuarioAsync(int id, AddUpdateUsuario usuariodata)
        {
            var usuario = _context.Usuarios.Find(id);  // Usar FindAsync para operaciones asincrónicas
            if (usuario == null) return null;

            usuario.Nom1 = usuariodata.Nom1;
            usuario.Nom2 = usuariodata.Nom2;
            usuario.Apellido1 = usuariodata.Apellido1;
            usuario.Apellido2 = usuariodata.Apellido2;
            usuario.Doc = usuariodata.Doc;
            usuario.Correo = usuariodata.Correo;
            usuario.Tel1 = usuariodata.Tel1;
            usuario.Tel2 = usuariodata.Tel2;
            usuario.Direccion = usuariodata.Direccion;
            usuario.Usuario1 = usuariodata.Usuario1;
            usuario.Password = usuariodata.Password;
            usuario.IsActive = usuariodata.IsActive;
            usuario.TipoDocId = usuariodata.TipoDocId;
            usuario.CiudadId = usuariodata.CiudadId;
             _context.SaveChanges(); 
            return usuario;
        }

        // Método asincrónico para eliminar un usuario por ID
        public bool DeleteUsuarioByIDAsync(int id)
        {
            var usuario =  _context.Usuarios.Find(id);  // Usar FindAsync
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();  // Usar SaveChangesAsync

            return true;
        }

        // Método asincrónico para obtener todos los usuarios
        public List<Usuario> GetAllUsuariosAsync(bool? isActive = null)
        {
            return isActive == null
                 ? _context.Usuarios.ToList()
                 : _context.Usuarios.Where(cel => cel.IsActive == isActive).ToList();
        }

        // Método asincrónico para obtener un usuario por ID
        public Usuario? GetUsuarioByIDAsync(int id)
        {
            return _context.Usuarios.Find(id);  // Usar FindAsync
        }

        // Método asincrónico para obtener todas las ciudades
        public  List<Ciudad> GetCiudadesAsync()
        {
            return _context.Ciudads.ToList();  // Suponiendo que tienes un DbSet<Ciudad>
        }

        // Método asincrónico para obtener todos los tipos de documento
        public List<TipoDocumento> GetTiposDocumentoAsync()
        {
            return  _context.TipoDocumentos.ToList();  // Suponiendo que tienes un DbSet<TipoDocumento>
        }
    }
}
