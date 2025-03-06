using System.Threading.Tasks;

namespace BookWorm_Dotnet.Services
{
    public interface IEmailService
    {
        Task SendOtpEmailAsync(string to, string otp);
    }
}
