using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWorm_Dotnet.Services;

namespace BookWorm_Dotnet.Controllers
{
    [ApiController]
    [Route("api/otp")]
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;
        private readonly IEmailService _emailService;

        public OtpController(IOtpService otpService, IEmailService emailService)
        {
            _otpService = otpService;
            _emailService = emailService;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] Dictionary<string, string> request)
        {
            if (!request.ContainsKey("email"))
                return BadRequest(new { Message = "Email is required" });

            string email = request["email"];
            string otp = _otpService.GenerateOtp(email);
            await _emailService.SendOtpEmailAsync(email, otp);

            return Ok(new { Message = "OTP sent successfully" });
        }
        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp([FromBody] Dictionary<string, string> request)
        {
            if (!request.ContainsKey("email") || !request.ContainsKey("otp"))
                return BadRequest(new { Message = "Email and OTP are required" });

            string email = request["email"];
            string otp = request["otp"];

            bool isValid = _otpService.ValidateOtp(email, otp);

            if (isValid)
                return Ok(new { Message = "OTP verified successfully" });
            else
                return BadRequest(new { Message = "Invalid or expired OTP" });
        }
    }
}
