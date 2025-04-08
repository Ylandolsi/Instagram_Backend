// using Instagram_Backend.Abstracts;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace Instagram_Backend.Services ;  

// public class StoryCleanupService : BackgroundService
// {
//     private readonly ILogger<StoryCleanupService> _logger;
//     private readonly IServiceProvider _serviceProvider;

//     public StoryCleanupService(
//         ILogger<StoryCleanupService> logger,
//         IServiceProvider serviceProvider)
//     {
//         _logger = logger;
//         _serviceProvider = serviceProvider;
//     }

//     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//     {
//         _logger.LogInformation("Story Cleanup Service running.");

//         while (!stoppingToken.IsCancellationRequested)
//         {
//             _logger.LogInformation("Story cleanup task running at: {time}", DateTimeOffset.Now);
            
//             try
//             {
//                 using (var scope = _serviceProvider.CreateScope())
//                 {
//                     var storyService = scope.ServiceProvider.GetRequiredService<IStoryService>();
//                     await storyService.CleanExpiredStoriesAsync();
//                 }
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Error occurred during story cleanup.");
//             }

//             // Run every hour
//             await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
//         }
//     }
// }