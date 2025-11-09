using Microsoft.Extensions.Configuration;

public class FileStorageService
{
    private readonly string _basePath;

    public FileStorageService(IConfiguration configuration)
    {
        _basePath = configuration["FileStorage:LetterPath"]
            ?? throw new ArgumentNullException("FileStorage:LetterPath is missing");

        if (!Directory.Exists(_basePath))
            Directory.CreateDirectory(_basePath);
    }

    public async Task<string> SaveFileAsync(byte[] fileData, string extension)
    {
        string fileName = $"{Guid.NewGuid()}{extension}";
        string fullPath = Path.Combine(_basePath, fileName);
        await File.WriteAllBytesAsync(fullPath, fileData);
        return fullPath;
    }

    public void DeleteFile(string path)
    {
        if (File.Exists(path))
            File.Delete(path);
    }
}
