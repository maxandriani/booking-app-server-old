using BookingApp.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Bookings.v1;

[ApiController]
[Route("v1/bookings/{bookingId}/contacts")]
public class BookingContactInfoController : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<CollectionResult<ContactInfoDto>>> IndexAsync(int bookingId, [FromQuery] SearchContactInfoRequest query)
  {
    var result = new CollectionResult<ContactInfoDto>(new List<ContactInfoDto>(), 0);
    return Ok(result);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<ContactInfoDto>> GetByIdAsync(int bookingId, int id)
  {
    var result = new ContactInfoDto();
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<ContactInfoDto>> CreateAsync(int bookingId, [FromBody] CreateUpdateContactInfoDto body)
  {
    var result = new ContactInfoDto();
    return CreatedAtAction(nameof(GetByIdAsync), new { BookingId = bookingId, Id = result.Id }, result);
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<ContactInfoDto>> UpdateAsync(int bookingId, int id, [FromBody] CreateUpdateContactInfoDto body)
  {
    var result = new ContactInfoDto();
    return Ok(result);
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> DeleteAsync(int bookingId, int id)
  {
    return Ok();
  }
}