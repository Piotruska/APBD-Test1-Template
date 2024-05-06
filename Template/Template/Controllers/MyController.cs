using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Services;

namespace PharmacyDB.Controllers;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    private ImyService _service;
    
    public MyController(ImyService service)
    {
        _service = service;
    }

    /// <summary>
    /// Endpoints used to .
    /// </summary>
    /// <returns>...</returns>
    /// HttpGet - Get data
    /// HttpPost - Add data
    /// HttpPut - Update Data
    /// HttpDelete - Selete Data

    [HttpPost("api/")]
    public async Task<IActionResult> Get()
    {
        var a = await _service.GetAsync();
        return Ok(a);
    }
    
    
}