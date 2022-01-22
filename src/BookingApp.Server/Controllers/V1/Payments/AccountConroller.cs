using BookingApp.Services.Requests;
using BookingApp.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Payments.v1;

[ApiController]
[Route("v1/accounts")]
public class AccountController : ControllerBase
{

  private IAccountService AccountService;

  public AccountController(IAccountService accountService)
  {
    AccountService = accountService;
  }

  [HttpGet]
  public async Task<ActionResult<CollectionResult<AccountDto>>> Index([FromQuery] SearchAccountRequest query)
  {
    var result = await AccountService.GetCollectionAsync(query);
    return Ok(result); 
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<AccountDto>> GetById(int id)
  {
    var result = await AccountService.GetByIdAsync(new GetByIdRequest { Id = id });
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<AccountDto>> Create([FromBody] CreateUpdateAccountDto body)
  {
    var result = await AccountService.CreateAsync(body);
    return CreatedAtAction(nameof(GetById), new { Id = result.Id }, result);
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<AccountDto>> Update(int id, [FromBody] CreateUpdateAccountDto body)
  {
    var result = await AccountService.UpdateAsync(new GetByIdRequest { Id = id }, body);
    return Ok(result);
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> Delete(int id)
  {
    await AccountService.DeleteAsync(new GetByIdRequest { Id = id });
    return Ok();
  }
}