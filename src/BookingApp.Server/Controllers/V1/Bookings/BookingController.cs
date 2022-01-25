using BookingApp.Services.Requests;
using BookingApp.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Bookings.v1;

[ApiController]
[Route("v1/bookings")]
public class BookingController : ControllerBase
{
  private IBookingService BookingService;

  public BookingController(IBookingService bookingService)
  {
    BookingService = bookingService;
  }

  [HttpGet]
  public async Task<ActionResult<CollectionResult<BookingDto>>> Index([FromQuery] SearchBookingRequestDto query)
  {
    var result = await BookingService.GetCollectionAsync(query);
    return Ok(result);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<BookingDto>> GetById(int id)
  {
    var result = await BookingService.GetByIdAsync(new GetByIdRequest { Id = id });
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<BookingDto>> Create([FromBody] CreateUpdateBookingDto body)
  {
    var result = await BookingService.CreateAsync(body);
    return CreatedAtAction(nameof(GetById), new { Id = result.Id },result);
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<BookingDto>> Update(int id, [FromBody] CreateUpdateBookingDto body)
  {
    var result = await BookingService.UpdateAsync(new GetByIdRequest { Id = id }, body);
    return Ok(result);
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> Delete(int id)
  {
    await BookingService.DeleteAsync(new GetByIdRequest { Id = id });
    return Ok();
  }
}