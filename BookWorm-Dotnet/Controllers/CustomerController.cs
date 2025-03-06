using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMyShelfService _myShelfService;
        private readonly ICartService _cartService;

        public CustomerController(ICustomerService customerService, IMyShelfService myShelfService, ICartService cartMasterService)
        {
            _customerService = customerService;
            _myShelfService = myShelfService;
            _cartService = cartMasterService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<CustomerMaster>> AddCustomer([FromBody] CustomerMaster customerMaster)
        {
            if (customerMaster == null)
            {
                return BadRequest("Data Not Found in RequestBody");
            }
            try
            {
                var existingcustomer = await _customerService.GetCustomerByEmailAsync(customerMaster.Customeremail);
                if (existingcustomer != null) return BadRequest(new { Message = "User allready Exists" });
                var customer = await _customerService.AddCustomerAsync(customerMaster);

                // Create a new instance of MyShelf and associate it with the customer
                var myShelf = new MyShelf { CustomerId = customer.CustomerId };
                await _myShelfService.AddMyShelfAsync(myShelf);

                // Create a new instance of CartMaster and associate it with the customer
                var cartMaster = new CartMaster { CustomerId = customer.CustomerId, IsActive = true };
                await _cartService.AddCartAsync(cartMaster);

                return Ok(new { Object = customer, Message = "Customer Added Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<CustomerMaster>> GetCustomerByEmailAsync(string email)
        {
            return await _customerService.GetCustomerByEmailAsync(email);
        }

        [HttpGet]
        public async Task<ActionResult<CustomerMaster>> GetAllCustomers()
        {
            return Ok(await _customerService.GetAllCustomersAsyn());
        }
    }
}