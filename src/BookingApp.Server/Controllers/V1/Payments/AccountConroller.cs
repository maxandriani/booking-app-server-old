using BookingApp.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Payments.v1;

[ApiController]
[Route("v1/accounts")]
public class AccountController : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<CollectionResult<AccountDto>>> IndexAsync([FromQuery] SearchAccountRequest query)
  {
    var result = new CollectionResult<AccountDto>(new List<AccountDto>(), 0);
    return Ok(result); 
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<AccountDto>> GetByIdAsync(int id)
  {
    var result = new AccountDto();
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<AccountDto>> CreateAsync([FromBody] CreateUpdateAccountDto body)
  {
    var result = new AccountDto();
    return CreatedAtAction(nameof(GetByIdAsync), new { Id = result.Id }, result);
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<AccountDto>> UpdateAsync(int id, [FromBody] CreateUpdateAccountDto body)
  {
    var result = new AccountDto();
    return Ok(result);
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> DeleteAsync(int id)
  {
    return Ok();
  }
}