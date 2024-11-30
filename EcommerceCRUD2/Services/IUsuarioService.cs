using EcommerceCRUD2.Models;


namespace EcommerceCRUD2.Services
{
    public interface IUsuarioService
    {
        // Métodos asincrónicos
        List<Usuario> GetAllUsuariosAsync(bool? isActive);
        Usuario? GetUsuarioByIDAsync(int id);
        Usuario CreateUsuarioAsync(AddUpdateUsuario obj);
        Usuario? UpdateUsuarioAsync(int id, AddUpdateUsuario obj);
        bool DeleteUsuarioByIDAsync(int id);

        // Métodos adicionales que puedas necesitar
        List<Ciudad> GetCiudadesAsync();
         List<TipoDocumento> GetTiposDocumentoAsync();
    }
}
