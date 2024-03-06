using BackEnd.Models;
using BackEnd.Business;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class AsientoController : ControllerBase
{
    private readonly IAsientoService _AsientoService;
    public AsientoController(IAsientoService AsientoService)
    {
        _AsientoService = AsientoService;
    }

    [HttpGet]
    public ActionResult<List<AsientosObra>> GetAll() =>
    _AsientoService.GetAll();


   // PILLAR SOLO 1 Asientos
    [HttpGet]
    [Route("{idFunction}/{idAsiento}")]
    public ActionResult<AsientosObra> GetAsiento(int idFunction, int idAsiento)
    {
        var Asiento = _AsientoService.GetAsiento(idFunction, idAsiento);

        if (Asiento == null){
            return NotFound();
        }else{
            return Asiento;
        }
    }

   // PILLAR TODAS LAS AsientosS DE 1 FUNCION
    [HttpGet]
    [Route("{id}")]
    public ActionResult<List<AsientosObra>> GetFromFunction(int id)
    {
        var Asiento = _AsientoService.GetFromFunction(id);

        if (Asiento == null){
            return NotFound();
        }else{
            return Asiento;
        }
    }




    [HttpPost]
    public IActionResult Create(AsientosObra Asiento)
    {
        _AsientoService.Add(Asiento);
        return CreatedAtAction(nameof(GetAsiento), new { id = Asiento.ObraId }, Asiento);
    }


 

    [HttpPut("{idFunction}/{idAsiento}")]
    public IActionResult Update(int idFunction, int idAsiento, AsientosObra Asiento)
    {
        if (idFunction != Asiento.ObraId)
            return BadRequest();

        var existingObra = _AsientoService.GetAsiento(idFunction, idAsiento);
        if (existingObra is null)
            return NotFound();

        _AsientoService.Update(Asiento);

        return NoContent();
    }




    [HttpDelete("{idFunction}/{idAsiento}")]
    public IActionResult Delete(int idFunction, int idAsiento)
    {
        var obra = _AsientoService.GetAsiento(idFunction, idAsiento);

        if (obra is null)
            return NotFound();

        _AsientoService.Delete(idFunction, idAsiento);

        return NoContent();
    }
}