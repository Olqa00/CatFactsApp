namespace CatFactsApp.WebUI.Services;

internal sealed class FileHostedService : IHostedService
{
    private readonly ILogger<FileHostedService> logger;

    public FileHostedService(ILogger<FileHostedService> logger)
    {
        this.logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            var settings = FileSettings.Instance;
            File.WriteAllText(settings.FilePath, string.Empty);

            this.logger.LogInformation("Created new file: {FileName}", settings.FileName);
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "Error creating file");
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
