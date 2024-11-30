using EcommerceCRUD2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCRUD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDocumentosController : ControllerBase
    {
        private readonly ecommercetechdbContext _DBContext;

        public TiposDocumentosController(ecommercetechdbContext context)
        {
            _DBContext = context;
        }

        [HttpGet]
        public IActionResult GetTiposDocumentos()
        {
            var tiposDocumentos = _DBContext.TipoDocumentos.ToList();
            return Ok(tiposDocumentos);
        }
    }
}
