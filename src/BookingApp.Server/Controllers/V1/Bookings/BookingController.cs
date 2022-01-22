using BookingApp.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Bookings.v1;

[ApiController]
[Route("v1/bookings")]
public class BookingController : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<CollectionResult<BookingDto>>> IndexAsync([FromQuery] SearchBookingRequestDto query)
  {
    var result = new CollectionResult<BookingDto>(new List<BookingDto>(), 0);
    return Ok(result);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<BookingDto>> GetByIdAsync(int id)
  {
    var result = new BookingDto();
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<BookingDto>> CreateAsync([FromBody] CreateBookingDto body)
  {
    var result = new BookingDto();
    return CreatedAtAction(nameof(GetByIdAsync), new { Id = result.Id },result);
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<BookingDto>> UpdateAsync(int id, [FromBody] UpdateBookingDto body)
  {
    var result = new BookingDto();
    return Ok(result);
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> DeleteAsync(int id)
  {
    return Ok();
  }
}