using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.Services
{
    public class OtpService : IOtpService
    {
        private readonly ConcurrentDictionary<string, string> _otpStorage = new ConcurrentDictionary<string, string>();

        public string GenerateOtp(string email)
        {
            string otp = new Random().Next(100000, 999999).ToString(); // 6-digit OTP
            _otpStorage[email] = otp;
            return otp;
        }

        public bool ValidateOtp(string email, string otp)
        {
            return _otpStorage.TryGetValue(email, out string storedOtp) && storedOtp == otp;
        }
    }
}
