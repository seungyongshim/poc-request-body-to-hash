using Microsoft.AspNetCore.Mvc;
using webapi.Dto;
using webapi.Filter;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class HashTestController : ControllerBase
{
    [HttpPost]
    [RequestHash]
    public async Task<ActionResult> Test([FromHeader] string? What,
                                         [FromBody] HelloDto hello)
    {
        return Ok(new
        {
            Body= hello,
            Hash= Request.Headers["HashSHA512"][0]
        });
    }
}
