namespace CatFactsApp.WebUI;

public sealed class FileSettings
{
    private const string DIRECTORY_NAME = "Data";
    private const string NAME = "CatFacts";
    private static readonly Lazy<FileSettings> INSTANCE = new(() => new FileSettings());

    public string FileName { get; }

    public string FilePath { get; }

    public static FileSettings Instance => INSTANCE.Value;

    public FileSettings()
    {
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        this.FileName = $"{NAME}_{timestamp}.txt";

        var directory = Path.Combine(Environment.CurrentDirectory, DIRECTORY_NAME);
        Directory.CreateDirectory(directory);

        this.FilePath = Path.Combine(directory, this.FileName);
    }
}
