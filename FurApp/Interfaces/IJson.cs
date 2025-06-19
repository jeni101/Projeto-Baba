using System.Threading.Tasks;

namespace Interfaces.Core
{
    public interface IJson
    {
        Task<string?> ReadFileAsync(string filePath);
        Task<bool> WriteFileAsync(string filePath, string content);
        bool FileExists(string filePath);
        bool DeleteFile(string filePath);
    }
}