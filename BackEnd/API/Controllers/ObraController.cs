using BackEnd.Models;
using BackEnd.Business;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class ObraController : ControllerBase
{
    private readonly IObraService _obraService;
    public ObraController(IObraService obraService)
    {
        _obraService = obraService;
    }

    [HttpGet]
public ActionResult<List<Obra>> GetAll() =>
    _obraService.GetAll();

    [HttpGet]
    [Route("{id}")]
public ActionResult<Obra> Get(int id)
{
    var obra = _obraService.Get(id);

    if(obra == null)
        return NotFound();

    return obra;
}

    [HttpPost]
public IActionResult Create(Obra obra)
{            
    _obraService.Add(obra);
    return CreatedAtAction(nameof(Get), new { id = obra.ObraId }, obra);
}
[HttpPut("{id}")]
public IActionResult Update(int obraId, [FromBody] ObraUpdateDTO obraDTO)
{
    if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try
        {
            _obraService.Update(obraId, obraDTO);
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
    var obra = _obraService.Get(id);
   
    if (obra is null)
        return NotFound();
       
    _obraService.Delete(id);
   
    return NoContent();
}
}