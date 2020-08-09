using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]

  public class ValuesController: ControllerBase
  {
    private readonly DataContext _context;
    public ValuesController(DataContext context)
    {
      _context = context;
    }
    // GET api/values
    [HttpGet]
    public async Task<IActionResult> GetValues() // IActionResults allows to return http response
    { 
      var values = await _context.Values.ToListAsync(); // return the values as a list
      return Ok(values);
    }

    // GET api/value/id
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetValue(int id)
    {
      var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
      return Ok(value);
    }
  }
}