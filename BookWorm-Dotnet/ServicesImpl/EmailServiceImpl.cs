using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace BookWorm_Dotnet.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _fromEmail;

        public EmailService(IConfiguration configuration)
        {
            var emailSettings = configuration.GetSection("EmailSettings");
            _fromEmail = emailSettings["FromEmail"];
            _smtpClient = new SmtpClient(emailSettings["SmtpServer"])
            {
                Port = int.Parse(emailSettings["Port"]),
                Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"]),
                EnableSsl = bool.Parse(emailSettings["EnableSsl"]),
                UseDefaultCredentials = bool.Parse(emailSettings["UseDefaultCredentials"])
            };

        }

        public async Task SendOtpEmailAsync(string to, string otp)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = "Your OTP for BookWorm Registration",
                Body = $"Your OTP is: {otp}\nIt is valid for 5 minutes.",
                IsBodyHtml = false
            };
            message.To.Add(to);
            try
            {
                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending email", ex);
            }
        }
    }
}
