using BackEnd.Models;
using BackEnd.Business;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class AsientoController : ControllerBase
{
    private readonly IAsientoService _asientoService;
    public AsientoController(IAsientoService asientoService)
    {
        _asientoService = asientoService;
    }

    [HttpGet]
    public ActionResult<List<AsientoGetDTO>> GetAll() =>
    _asientoService.GetAll();


   // PILLAR SOLO 1 Asientos
    /* [HttpGet]
    [Route("{idFunction}/{idAsiento}")]
    public ActionResult<AsientosObra> GetAsiento(int idFunction, int idAsiento)
    {
        var Asiento = _AsientoService.GetAsiento(idFunction, idAsiento);

        if (Asiento == null){
            return NotFound();
        }else{
            return Asiento;
        }
    } */

   // PILLAR TODAS LAS AsientosS DE 1 FUNCION
    /* [HttpGet]
    [Route("{id}")]
    public ActionResult<List<AsientosObra>> GetFromFunction(int id)
    {
        var Asiento = _AsientoService.GetFromFunction(id);

        if (Asiento == null){
            return NotFound();
        }else{
            return Asiento;
        }
    } */

    [HttpGet]
    [Route("{id}")]
public ActionResult<Asiento> Get(int id)
{
    var asiento = _asientoService.Get(id);

    if(asiento == null)
        return NotFound();

    return asiento;
}


    [HttpPost]
    public IActionResult Create(Asiento asiento)
    {
        _asientoService.Add(asiento);
        return CreatedAtAction(nameof(Get), new { id = asiento.AsientoId }, asiento);
    }

[HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] AsientoUpdateDTO asientoUpdateDTO)
{
    if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try
        {
            _asientoService.Update(id, asientoUpdateDTO);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
           return NotFound();
        }
}



     [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var asiento = _asientoService.Get(id);
   
    if (asiento is null)
        return NotFound();
       
    _asientoService.Delete(id);
   
    return NoContent();
}
}