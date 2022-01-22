using BookingApp.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Payments.v1;

[ApiController]
[Route("v1/payments")]
public class PaymentController : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<CollectionResult<PaymentDto>>> Index([FromQuery] SearchPaymentRequest query)
  {
    var result = new CollectionResult<PaymentDto>(new List<PaymentDto>(), 0);
    return Ok(result); 
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<PaymentDto>> GetByIdAsyn(int id)
  {
    var result = new PaymentDto();
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<PaymentDto>> CreateAsync([FromBody] CreateUpdateAccountDto body)
  {
    var result = new PaymentDto();
    return CreatedAtAction(nameof(GetByIdAsyn), new { Id = result.Id }, result);
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<PaymentDto>> UpdateAsync(int id, [FromBody] CreateUpdateAccountDto body)
  {
    var result = new PaymentDto();
    return Ok(result);
  }

  [HttpDelete]
  public async Task<ActionResult> DeleteAsync(int id)
  {
    var result = new PaymentDto();
    return Ok();
  }
}