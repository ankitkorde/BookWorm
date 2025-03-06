using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;
using BookWorm_Dotnet.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.BookWorm.DTOs;
using BookWorm_Dotnet.ServicesImpl;

namespace Project.BookWorm.Controllers
{
    [Route("api/cart-details")]
    [ApiController]
    public class CartDetailsController : ControllerBase
    {
        private readonly ICartDetailsService _cartDetailsService;
        private readonly ICartService _cartMasterService;
        private readonly ILogger<CartDetailsController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        //private readonly CheckOutService _checkOutService;

        public CartDetailsController(
            ICartDetailsService cartDetailsService,
            ICartService cartMasterService,
            ILogger<CartDetailsController> logger,
            ICustomerService customerService,
            IProductService productService)
            
        {
            _cartDetailsService = cartDetailsService;
            _cartMasterService = cartMasterService;
            _logger = logger;
            _customerService = customerService;
            _productService = productService;
        }

        // Add product to a customer's cart
        [HttpPost("add")]
        public async Task<IActionResult> AddProductToCart([FromBody] CartDetailsRequest cartDetailsRequest)
        {
            System.Diagnostics.Debug.WriteLine("--------------------------------"+cartDetailsRequest.ProductId);
            var cartDetails = await _cartDetailsService.AddProductToCartAsync(
                cartDetailsRequest.CustomerId,
                cartDetailsRequest.ProductId,
                cartDetailsRequest.rentNoOfDays,
                cartDetailsRequest.TransType
            );

            _logger.LogInformation($"Product added to cart: {cartDetails}");

            var crt = await _cartMasterService.GetCartByCustomerId(cartDetailsRequest.CustomerId);
            // Update the cart cost
            await _cartMasterService.UpdateCartCost(crt);

            return CreatedAtAction(nameof(GetCartDetailsById), new { id = cartDetails.CartDetailsId }, cartDetails);
        }

        // Get all cart details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetail>>> GetAllCartDetails()
        {
            return Ok(await _cartDetailsService.GetAllCartDetailsAsync());
        }

        // Get cart details by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetail>> GetCartDetailsById(int id)
        {
            var cartDetails = await _cartDetailsService.GetCartDetailsByIdAsync(id);
            if (cartDetails == null)
                return NotFound();

            return Ok(cartDetails);
        }

        // Get cart details by customer ID
        [HttpGet("customer/{email}")]
        public async Task<ActionResult<IEnumerable<CartDetail>>> GetCartDetailsByCustomerId(string email)
        {
            var cust = await _customerService.GetCustomerByEmailAsync(email);
            if (cust == null) return NotFound("Customer not found");

            var crt = await _cartMasterService.GetCartByCustomerId(cust.CustomerId);
            if (crt == null) return NotFound("Cart not found");

            var cartDetails = await _cartDetailsService.GetCartDetailsByCartIdAsync(crt.CartId);
            if (cartDetails == null || cartDetails.Count == 0) return NotFound("No cart details found");

            // Fetch all products in one query instead of multiple DB calls
            var productIds = cartDetails.Select(cd => (int)cd.ProductId).ToList();
            var products = await _productService.GetProductsByIdsAsync(productIds); // Bulk fetch

            return Ok(new { cart = cartDetails,product = products });
        }


        // Check if product is in cart
        [HttpGet("customer/{customerId}/product/{productId}")]
        public async Task<IActionResult> IsProductInCart(int customerId, int productId)
        {
            var crt = await _cartMasterService.GetCartByCustomerId(customerId);

            var cartDetails = await _cartDetailsService.GetCartDetailsByCartIdAsync(crt.CartId);
            //if (cartDetails == null || cartDetails.Count == 0)
            //    return NotFound("No Product in Cart");
            foreach ( CartDetail c in cartDetails)
            {
                if (c.ProductId == productId)
                    return Ok();
            }
            return BadRequest("Product Not in Cart");
        }

        // Update cart details
         [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCartDetails(int id, [FromBody] CartDetail updatedItem)
        {
            if (updatedItem == null || id != updatedItem.CartDetailsId)
            {
                return BadRequest("Invalid request data");
            }

            try
            {
                var existingItem = await _cartDetailsService.GetCartDetailsByIdAsync(id);
                if (existingItem == null)
                {
                    return NotFound("Cart item not found");
                }

                // Update only necessary fields of the existing entity
                existingItem.IsRented = updatedItem.IsRented;
                existingItem.RentNoOfDays = updatedItem.RentNoOfDays;
                existingItem.OfferCost = updatedItem.OfferCost;

                // Save the updated existing entity, NOT updatedItem
                var result = await _cartDetailsService.SaveCartDetailsAsync(existingItem);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error updating cart item: " + ex.Message);
            }
        }


        // Delete cart details by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartDetails(int id)
        {
            await _cartDetailsService.DeleteCartDetailsAsync(id);
            return Ok() ;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CheckoutCart([FromBody] string email)
        {
            if (email==null)
            {
                return BadRequest("Invalid customer ID");
            }

            CartMaster cart = await _cartMasterService.CheckoutCart(email);
            return Ok(cart);
        }

    }
}
