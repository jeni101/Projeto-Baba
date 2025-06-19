using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Interfaces.Core;

namespace Services.Json
{
    public class JsonServices : IJson
    {
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly string _baseDirectory;

        public JsonServices(string baseDirectory)
        {
            if (string.IsNullOrWhiteSpace(baseDirectory))
                throw new ArgumentNullException("O diretório base não pode ser nulo ou vazio.", nameof(baseDirectory));
            
            _baseDirectory = baseDirectory;
            if (!Directory.Exists(_baseDirectory))
            {
                Directory.CreateDirectory(_baseDirectory);
                Console.WriteLine($"Diretório de persistência JSON criado: {_baseDirectory}");
            }

            _jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };
        }

        private string GetFullPath(string fileName)
        {
            return Path.Combine(_baseDirectory, fileName);
        }

        public async Task<string?> ReadFileAsync(string fileName)
        {
            string filePath = GetFullPath(fileName);

            if (!FileExists(filePath))
            {
                Console.WriteLine($"Aviso: Arquivo JSON '{fileName}' não encontrado em '{_baseDirectory}'.");
                return null;
            }

            try
            {
                return await File.ReadAllTextAsync(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo JSON '{fileName}' em '{_baseDirectory}': {ex.Message}");
                return null;
            }
        }

        public async Task<bool> WriteFileAsync(string fileName, string content)
        {
            string filePath = GetFullPath(fileName);

            try
            {
                await File.WriteAllTextAsync(filePath, content);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no arquivo JSON '{fileName}' em '{_baseDirectory}': {ex.Message}");
                return false;
            }
        }

        public bool FileExists(string fileName)
        {
            return File.Exists(GetFullPath(fileName));
        }

        public bool DeleteFile(string fileName)
        {
            string filePath = GetFullPath(fileName);

            if (!FileExists(filePath))
            {
                Console.WriteLine($"Aviso: Não foi possível deletar. Arquivo JSON '{fileName}' não encontrado em '{_baseDirectory}'.");
                return true;
            }

            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o arquivo JSON '{fileName}' em '{_baseDirectory}': {ex.Message}");
                return false;
            }
        }

        public string Serialize<T>(T data)
        {
            return JsonSerializer.Serialize(data, _jsonOptions);
        }

        public T? Deserialize<T>(string jsonContent)
        {
            return JsonSerializer.Deserialize<T>(jsonContent, _jsonOptions);
        }
    }
}