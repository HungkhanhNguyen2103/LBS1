
using Repositories.IRepository;

namespace IReadingAPI
{
    public class BackgroundTask : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<IBookIndexingRepository> _logger;
        public BackgroundTask(IServiceProvider serviceProvider, ILogger<IBookIndexingRepository> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("IBookIndexingRepository is starting...");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<IBookIndexingRepository>();

                    try
                    {
                        await service.SyncMeilisearch();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error while syncing books.");
                    }
                }

                // Lặp lại mỗi 3 giờ 
                await Task.Delay(TimeSpan.FromHours(3), stoppingToken);
            }
        }
    }
}
