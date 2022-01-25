using BookingApp.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Bookings.v1;

[ApiController]
[Route("v1/bookings/{bookingId}/contacts")]
public class BookingContactInfoController : ControllerBase
{
  private IContactInfoService ContactInfoService;

  public BookingContactInfoController(IContactInfoService contactInfoService)
  {
    ContactInfoService = contactInfoService;
  }

  [HttpGet]
  public async Task<ActionResult<CollectionResult<ContactInfoDto>>> Index(string bookingId, [FromQuery] BookingContactInfoSearchRequest query)
  {
    var request = new SearchContactInfoRequest() { Search = query.Search };
    request.BookingId = (bookingId.Equals("-"))
      ? 0
      : int.Parse(bookingId);

    var result = await ContactInfoService.GetCollectionAsync(request);
    return Ok(result);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<ContactInfoDto>> GetById(int bookingId, int id)
  {
    var result = await ContactInfoService.GetByIdAsync(new ContactInfoKeysDto()
    {
      BookingId = bookingId,
      Id = id
    });
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<ContactInfoDto>> Create(int bookingId, [FromBody] BookingContactInfoCreateUpdateRequest body)
  {
    var data = new CreateUpdateContactInfoDto()
    {
      BookingId = bookingId,
      Kind = body.Kind,
      Value = body.Value
    };
    var result = await ContactInfoService.CreateAsync(data);
    return CreatedAtAction(nameof(GetById), new { BookingId = bookingId, Id = result.Id }, result);
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<ContactInfoDto>> Update(int bookingId, int id, [FromBody] BookingContactInfoCreateUpdateRequest body)
  {
    var data = new CreateUpdateContactInfoDto()
    {
      BookingId = bookingId,
      Kind = body.Kind,
      Value = body.Value
    };
    var result = await ContactInfoService.UpdateAsync(new ContactInfoKeysDto() { Id = id, BookingId = bookingId }, data);
    return Ok(result);
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> Delete(int bookingId, int id)
  {
    await ContactInfoService.DeleteAsync(new ContactInfoKeysDto { Id = id, BookingId = bookingId });
    return Ok();
  }
}