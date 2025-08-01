﻿namespace CatFactsApp.WebUI.Interfaces;

public interface IFileService
{
    Task AppendToFileAsync(string content, CancellationToken cancellationToken = default);
}
