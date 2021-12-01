using CustomersApp.Api.DataAccess;
using CustomersApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomersApp.Api.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
     
        private readonly ILogger<CustomersController> _logger;
        private CustomerDbContext _context;

        public CustomersController()
        {
            _context = new CustomerDbContext();
        }

        ///Customers/id
        [HttpGet]
        public Customer Get(int id)
        {
            return _context.GetCustomer(id);
        }

        [HttpPost]
        public Customer Add(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Validate())) return _context.Create(customer);
            return new Customer();
        }

        [HttpDelete]
        public void Delete(int customerId)
        {
            _context.Remove(customerId);
        }

    }
}
