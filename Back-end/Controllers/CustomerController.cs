using Back_end.Dtos;
using Back_end.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {

        private readonly CustomerDataBaseContext _customerDataBaseContext;

        public CustomerController(CustomerDataBaseContext customerDataBaseContext) 
        {
            _customerDataBaseContext = customerDataBaseContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> getCustomer(long id) 
        {
            CustomerEntity result = await _customerDataBaseContext.Get(id);
            return new OkObjectResult(result.ToDto());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> getCustomers() 
        {
            var list = _customerDataBaseContext.Customers.Select(c => c.ToDto()).ToList();
            return new OkObjectResult(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        public async Task<IActionResult> createCustomer(CreateCustomerDto customer) 
        {
            CustomerEntity result = await _customerDataBaseContext.Add(customer);
            return new CreatedResult($"https://localhost:7209/api/customer/{result.id}", null);
        }

        [HttpPut]
        public async Task<bool> updateCustomer(CustomerDto customer) 
        {
            return false;
        }

        [HttpDelete("{id}")]
        public async Task<bool> deleteCustomer(long id) 
        { 
            return false ;
        }
    }
}
