using FJob.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace FJOB.Infrastructure.Utils.FileUpload;

public class FileService:IFileService
{
    private readonly IEnvironmentAccessor _environmentAccessor;

    public FileService(IEnvironmentAccessor environmentAccessor)
    {
        _environmentAccessor = environmentAccessor;
    }

    public async Task UploadFile(IFormFile file, string path)
    {
        if (file is null || file.Length == 0)
            throw new FJOBException("No file was provided or file is empty");

        if (string.IsNullOrEmpty(path))
        {
            throw new FJOBException("Path was not provided");
        }
        path = Path.Combine(_environmentAccessor.GetWebRootPath(), path);

        Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        using var fileStream = File.Create(path);

        await file.CopyToAsync(fileStream);
    }

    public void RemoveFile(string path)
    {
        path = Path.Combine(_environmentAccessor.GetWebRootPath(), path);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}

//namespace CMS.Core.Abstract;
public interface IEnvironmentAccessor
{
    string GetFullName();
    string GetWebRootPath();
    bool HasRole(string role);
}