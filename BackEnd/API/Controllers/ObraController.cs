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
public ActionResult<List<ObraGetDTO>> GetAll() =>
    _obraService.GetAll();

    [HttpGet]
    [Route("{id}")]
public ActionResult<ObraGetDTO> Get(int id)
{
    var obra = _obraService.Get(id);

    if(obra == null)
        return NotFound();

    return obra;
}

    [HttpPost]
public IActionResult Create(ObraCreateDTO obraCreateDTO)
{            
     if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _obraService.Add(obraCreateDTO);
        return Ok();
}

[HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] ObraUpdateDTO obraUpdateDTO)
{
    if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try
        {
            _obraService.Update(id, obraUpdateDTO);
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