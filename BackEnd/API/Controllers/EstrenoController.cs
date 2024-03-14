using BackEnd.Models;
using BackEnd.Business;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class EstrenoController : ControllerBase
{
    private readonly IEstrenoService _EstrenoService;
    public EstrenoController(IEstrenoService EstrenoService)
    {
        _EstrenoService = EstrenoService;
    }

    [HttpGet]
public ActionResult<List<EstrenoGetDTO>> GetAll() =>
    _EstrenoService.GetAll();

    [HttpGet]
    [Route("{id}")]
public ActionResult<EstrenoGetDTO> Get(int id)
{
    var Estreno = _EstrenoService.Get(id);

    if(Estreno == null)
        return NotFound();

    return Estreno;
}

    [HttpPost]
public IActionResult Create(EstrenoCreateDTO EstrenoCreateDTO)
{            
     if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _EstrenoService.Add(EstrenoCreateDTO);
        return Ok();
}

[HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] EstrenoUpdateDTO EstrenoUpdateDTO)
{
    if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try
        {
            _EstrenoService.Update(id, EstrenoUpdateDTO);
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
    var Estreno = _EstrenoService.Get(id);
   
    if (Estreno is null)
        return NotFound();
       
    _EstrenoService.Delete(id);
   
    return NoContent();
}
}