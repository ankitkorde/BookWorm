using System.Threading.Tasks;

namespace BookWorm_Dotnet.Services
{
    public interface IOtpService
    {
        string GenerateOtp(string email);
        bool ValidateOtp(string email, string otp);
    }
}
