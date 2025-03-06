namespace BookWorm_Dotnet.Services
{
    public interface IJwtService
    {
        Task<string> AuthenticateAsync(string email, string password);

        string GenerateJwtToken(CustomerMaster customerMaster);

        //Task AddUserAsync(string email, string password);
    }
}
    

