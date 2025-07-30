namespace CatFactsApp.WebUI.Services;

using CatFactsApp.WebUI.Interfaces;

public sealed class FileService : IFileService
{
    private const string DIRECTORY_NAME = "Data";
    private const string FILE_NAME = "catfacts.txt";

    private static readonly string FILE_PATH = Path.Combine(
        Environment.CurrentDirectory,
        DIRECTORY_NAME,
        FILE_NAME);

    private readonly ILogger<FileService> logger;

    public FileService(ILogger<FileService> logger)
    {
        this.logger = logger;
    }

    public async Task AppendToFileAsync(string content, CancellationToken cancellationToken = default)
    {
        try
        {
            await File.AppendAllTextAsync(FILE_PATH, content + Environment.NewLine, cancellationToken);
            this.logger.LogInformation("Appended content to file");
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "Error writing to file");

            throw;
        }
    }

    public async Task ClearFileAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (File.Exists(FILE_PATH) is true)
            {
                await File.WriteAllTextAsync(FILE_PATH, string.Empty, cancellationToken);
                this.logger.LogInformation("File cleaned on startup");
            }
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "Error cleaning file on startup");

            throw;
        }
    }
}
