using EcommerceCRUD2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcommerceCRUD2.Services;


namespace EcommerceCRUD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            // Llamamos al servicio sin el parámetro isActive
            return Ok(_usuarioService.GetAllUsuariosAsync(isActive));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioService.GetUsuarioByIDAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(AddUpdateUsuario usuarioObject)
        {
            var usuario = _usuarioService.CreateUsuarioAsync(usuarioObject);
            return Ok(new
            {
                message = "Usuario creado exitosamente.",
                id = usuario.IdUsuario
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateUsuario usuarioObject)
        {
            var usuario = _usuarioService.UpdateUsuarioAsync(id, usuarioObject);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Usuario actualizado exitosamente.",
                id = usuario.IdUsuario
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
           
            

            if (!_usuarioService.DeleteUsuarioByIDAsync(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Usuario eliminado exitosamente.",
                id = id
            });
        }
    }   
}
