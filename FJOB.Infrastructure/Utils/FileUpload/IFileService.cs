using Microsoft.AspNetCore.Http;

namespace FJOB.Infrastructure.Utils.FileUpload;

public interface IFileService
{
    Task UploadFile(IFormFile file, string path);

    void RemoveFile(string path);
}
