using BookWorm_Dotnet.DTOs;
using BookWorm_Dotnet.Services;
using BookWorm_Dotnet.ServicesImpl;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BookWorm_Dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly ICustomerService _customerService;
        private readonly IUserActivityService _userActivityService;

        public LoginController(IJwtService jwtService, ICustomerService customerService, IUserActivityService userActivityService)
        {
            _jwtService = jwtService;
            _customerService = customerService;
            _userActivityService = userActivityService;
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            if (!Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                return BadRequest(new { Message = "Authorization header not found" });
            }

            if (!authHeader.ToString().StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                return Unauthorized(new { Message = "Invalid Authorization header format" });
            }

            // Extract Base64 credentials
            string encodedCredentials = authHeader.ToString().Substring("Basic ".Length).Trim();

            try
            {
                // Decode credentials
                byte[] credentialBytes = Convert.FromBase64String(encodedCredentials);
                string decodedCredentials = Encoding.UTF8.GetString(credentialBytes);
                var credentials = decodedCredentials.Split(':');
                if (credentials.Length != 2)
                {
                    return Unauthorized(new { Message = "Invalid credentials format" });
                }

                string email = credentials[0];
                string password = credentials[1];
                System.Diagnostics.Debug.WriteLine("--------------------------------------------" + email + " -- " + password);

                // 1️⃣ Check if the user exists in the database
                var customer = await _customerService.GetCustomerByEmailAsync(email);
                if (customer == null)
                {
                    return BadRequest(new { Message = "User Doesn't Exist" });
                }

                // 2️⃣ Validate email and password
                var existingUser = await _customerService.GetCustomerByEmailAndPasswordAsync(email, password);
                if (existingUser == null)
                {
                    return BadRequest(new { Message = "Incorrect Password" });
                }

                // 3️⃣ Generate JWT token
                string token = await _jwtService.AuthenticateAsync(email, password);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized(new { Message = "Authentication failed" });
                }

                // 4️⃣ Log login activity
                await _userActivityService.LogActivity(existingUser.Customeremail, "Login");

                Response.Headers.Add("Authorization", $"Bearer {token}");

                return Ok(new { Token = token, User = existingUser, Message = "Login Successful" });
            }
            catch (FormatException)
            {
                return Unauthorized(new { Message = "Invalid Base64 encoding in Authorization header" });
            }
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string email)
        {
            // Log the logout action
            await _userActivityService.LogActivity(email, "Logout");

            return Ok(new { Message = "Logout Successful" });
        }
    }
}
