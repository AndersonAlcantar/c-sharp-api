using Back_end.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> getCustomer(long id) 
        {
            var result = new CustomerDto(); 
            return new OkObjectResult(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> getCustomers() 
        {
            var list = new List<CustomerDto>();
            return new OkObjectResult(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.)]
        public async Task<IActionResult> createCustomer(CreateCustomerDto customer) 
        {
            var result = new CustomerDto();
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
