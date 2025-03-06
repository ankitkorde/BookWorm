using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.Services;
using System;

namespace BookWorm_Dotnet.ServicesImpl
{
    public class UserActivityServiceImpl : IUserActivityService
    {
        private readonly BookWormDbContext _context;

        public UserActivityServiceImpl(BookWormDbContext context)
        {
            _context = context;
        }

        public async Task LogActivity(string userId, string action)
        {
            var logEntry = new UserActivityLog
            {
                CustomerEmail = userId,
                Action = action,
                Timestamp = DateTime.UtcNow
            };

            await _context.UserActivityLogs.AddAsync(logEntry);
            await _context.SaveChangesAsync();
        }

    }
}
