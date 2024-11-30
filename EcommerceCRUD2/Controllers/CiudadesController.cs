using EcommerceCRUD2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CiudadesController : ControllerBase
{
    private readonly ecommercetechdbContext _ciudad;

    public CiudadesController(ecommercetechdbContext ciudadService)
    {
        _ciudad = ciudadService;
    }

    [HttpGet]
    public IActionResult Getciudades()
    {
        var Ciudades = _ciudad.Ciudads.ToList();
        return Ok(Ciudades);

    }
}