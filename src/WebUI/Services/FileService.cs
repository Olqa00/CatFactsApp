namespace CatFactsApp.WebUI.Services;

using CatFactsApp.WebUI.Interfaces;

public sealed class FileService : IFileService
{
    private readonly ILogger<FileService> logger;

    public FileService(ILogger<FileService> logger)
    {
        this.logger = logger;
    }

    public async Task AppendToFileAsync(string content, CancellationToken cancellationToken = default)
    {
        try
        {
            var path = FileSettings.Instance.FilePath;

            await File.AppendAllTextAsync(path, content + Environment.NewLine, cancellationToken);
            this.logger.LogInformation("Appended content to file");
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "Error writing to file");

            throw;
        }
    }
}
