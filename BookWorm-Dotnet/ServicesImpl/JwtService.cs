using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Text;



namespace BookWorm_Dotnet.ServicesImpl
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly BookWormDbContext _context;

        public JwtService(IConfiguration configuration, BookWormDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }



        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
        }





        public async Task<string> AuthenticateAsync(string email, string password)
        {
            // Check if the user exists in the database
            var customermaster = await _context.CustomerMasters
                .Where(s => s.Customeremail == email)
                .FirstOrDefaultAsync();

            if (customermaster == null)
            {
                throw new Exception("Invalid Credentials");
            }

            //Verify password(Assuming passwords are stored as hashes)
            if (!VerifyPassword(password, customermaster.Customerpassword))
            {
                throw new Exception("Invalid Credentials");
            }

            //if(password != customermaster.Customerpassword)
            //{
            //    throw new Exception("Invalid Credentials");
            //}

            return GenerateJwtToken(customermaster);
        }



        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }



        public string GenerateJwtToken(CustomerMaster customerMaster)
        {
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"] ?? "BookWorm"), //
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(ClaimTypes.NameIdentifier, staff.StaffId.ToString()),
                    //new Claim("UserId", user.UserId.ToString()), // Teaching or Non-Teaching
                    new Claim("Email", customerMaster.Customeremail),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                };

            //Generates faltugiri code over here using this key 
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("JWT Key not found"))
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // algoritham for hashing 

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"] ?? "60")),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
