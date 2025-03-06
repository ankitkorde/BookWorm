using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Repository;

namespace BookWorm_Dotnet.ServicesImpl
{
    public class DatabaseLogger : ILogger
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly string _categoryName;

        public DatabaseLogger(IServiceScopeFactory scopeFactory, string categoryName)
        {
            _scopeFactory = scopeFactory;
            _categoryName = categoryName;
        }

        public IDisposable? BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true; // Log everything

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (formatter == null) return;

            var logEntry = new LogEntry
            {
                Timestamp = DateTime.UtcNow,
                LogLevel = logLevel.ToString(),
                Message = formatter(state, exception),
                Exception = exception?.ToString()
            };

            // Fire and forget with proper exception handling
            _ = Task.Run(() => SaveLogAsync(logEntry)).ConfigureAwait(false);
        }

        private async Task SaveLogAsync(LogEntry logEntry)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<BookWormDbContext>();

                dbContext.LogEntries.Add(logEntry);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving log: {ex.Message}");
            }
        }
    }

    public class DatabaseLoggerProvider : ILoggerProvider
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DatabaseLoggerProvider(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public ILogger CreateLogger(string categoryName) => new DatabaseLogger(_scopeFactory, categoryName);

        public void Dispose() { }
    }
}
