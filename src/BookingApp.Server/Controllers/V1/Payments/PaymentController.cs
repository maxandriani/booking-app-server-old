using BookingApp.Services.Requests;
using BookingApp.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Payments.v1;

[ApiController]
[Route("v1/payments")]
public class PaymentController : ControllerBase
{
  private IPaymentService PaymentService;

  public PaymentController(IPaymentService paymentService)
  {
    this.PaymentService = paymentService;
  }

  [HttpGet]
  public async Task<ActionResult<CollectionResult<PaymentDto>>> Index([FromQuery] SearchPaymentRequest query)
  {
    var result = await PaymentService.GetCollectionAsync(query);
    return Ok(result); 
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<PaymentDto>> GetById(int id)
  {
    var result = await PaymentService.GetByIdAsync(new GetByIdRequest { Id = id});
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<PaymentDto>> Create([FromBody] CreateUpdatePaymentDto body)
  {
    var result = await PaymentService.CreateAsync(body);
    return CreatedAtAction(nameof(GetById), new { Id = result.Id }, result);
  }

  [HttpPost("{id:int}/confirm")]
  public async Task<ActionResult<PaymentDto>> Confirm(int id, [FromBody] ConfirmPaymentDto body)
  {
    var result = await PaymentService.ConfirmAsync(new GetByIdRequest { Id = id }, body);
    return Ok(result);
  }

  [HttpPost("{id:int}/unconfirm")]
  public async Task<ActionResult<PaymentDto>> UnConfirm(int id)
  {
    var result = await PaymentService.UnConfirmAsync(new GetByIdRequest { Id = id });
    return Ok(result);
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<PaymentDto>> Update(int id, [FromBody] CreateUpdatePaymentDto body)
  {
    var result = await PaymentService.UpdateAsync(new GetByIdRequest { Id = id }, body);
    return Ok(result);
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> Delete(int id)
  {
    await PaymentService.DeleteAsync(new GetByIdRequest { Id = id });
    return Ok();
  }
}