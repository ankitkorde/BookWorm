namespace BookWorm_Dotnet.Services
{
    public interface IUserActivityService
    {
        public Task LogActivity(string userId, string action);

    }
}
