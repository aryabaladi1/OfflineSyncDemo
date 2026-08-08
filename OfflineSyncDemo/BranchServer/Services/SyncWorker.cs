using Microsoft.Extensions.Hosting;

namespace BranchServer.Services;

public class SyncWorker : BackgroundService
{
    private readonly HttpClient _httpClient;

    public SyncWorker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Checking for pending sales...");

            var pendingSales = LocalStorage.PendingSync.ToList();

            if (pendingSales.Any())
            {
                Console.WriteLine("Sending sale updates to central server...");

                try
                {
                    var response = await _httpClient.PostAsJsonAsync(
                        "https://localhost:7089/api/Sync/sales",
                        pendingSales,
                        stoppingToken
                    );

                    if (response.IsSuccessStatusCode)
                    {
                        LocalStorage.PendingSync.RemoveAll(
                            x => pendingSales.Contains(x)
                        );

                        Console.WriteLine($"Synced {pendingSales.Count} sales");
                    }
                    else
                    {
                        Console.WriteLine("Sync failed, keeping queue");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Sync error: {ex.Message}");
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}