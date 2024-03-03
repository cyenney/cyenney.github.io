using Microsoft.AspNetCore.Mvc;
using webapi.DAL;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    public CustomerRepository _customerRepository;
    public CustomersController(CustomerRepository customerRepository) 
    { 
        _customerRepository = customerRepository;
    }

    [HttpPost("register")]
    public ActionResult RegisterCustomer()
    {
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult<Guid> CustomerLogin(LoginCustomer customer)
    {
        var foundCustomer = _customerRepository.GetCustomer(customer);
        if (foundCustomer != null)
        {
            return foundCustomer.Id;
        }
        else
        {
            return NotFound();
        }
        
    }

}
