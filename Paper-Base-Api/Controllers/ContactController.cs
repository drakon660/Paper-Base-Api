using Microsoft.AspNetCore.Mvc;

namespace Paper_Base_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly ContactService _contactService;

    public ContactController(ContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet("")]
    public IEnumerable<Contact> All()
    {
        return _contactService.GetAll();
    }
    
    [HttpPost("")]
    public IActionResult Add([FromBody] Contact contact)
    {
        _contactService.Add(contact);
        return Ok(contact.Id);
    }

    [HttpDelete("{id:guid}")] 
    public IActionResult Delete(Guid id)
    {
        _contactService.Remove(id);
        return Ok();
    }
    
    [HttpPut("{id:guid}")] 
    public IActionResult Update(Guid id, Contact contact)
    {
        _contactService.Update(id, contact);
        return Ok();
    }
}