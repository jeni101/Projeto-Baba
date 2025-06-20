using System;
using System.Collections.Generic;
using System.IO; 
using System.Linq;
using System.Threading.Tasks;
using Interfaces.IRepository;
using Services.Json; 
using Models; 

namespace Repository.PersistenciaApp
{
    public abstract class ARepository<T> : IRepository<T>
        where T : AModel
    {
        protected readonly JsonServices _jsonServices;
        protected readonly string _fileName;

        public ARepository(JsonServices jsonServices, string fileName)
        {
            _jsonServices = jsonServices ?? throw new ArgumentNullException(nameof(jsonServices));
            _fileName = !string.IsNullOrWhiteSpace(fileName)
                ? fileName
                : throw new ArgumentException("O nome do arquivo não pode ser nulo ou vazio.", nameof(fileName));
        }

        public async Task<bool> SalvarAsync(T entity)
        {
            if (entity == null)
            {
                Console.WriteLine($"Erro: O objeto {typeof(T).Name} não pode ser nulo ao salvar.");
                return false;
            }

            var entities = await GetAll();
            
            if (entities.Any(e => e.Id == entity.Id))
            {
                Console.WriteLine($"Erro: Entidade {typeof(T).Name} com ID '{entity.Id}' já existe. Use AtualizarAsync para modificar.");
                return false;
            }

            entities.Add(entity);

            string jsonContent = _jsonServices.Serialize(entities);
            return await _jsonServices.WriteFileAsync(_fileName, jsonContent);
        }

        public async Task<bool> AtualizarAsync(T entity)
        {
            if (entity == null)
            {
                Console.WriteLine($"Erro: O objeto {typeof(T).Name} não pode ser nulo ao atualizar.");
                return false;
            }

            var entities = await GetAll();
            var existingEntity = entities.FirstOrDefault(e => e.Id == entity.Id);

            if (existingEntity == null)
            {
                Console.WriteLine($"Erro: Entidade {typeof(T).Name} com ID '{entity.Id}' não encontrada para atualização.");
                return false;
            }

            var index = entities.IndexOf(existingEntity);
            entities[index] = entity; 

            string jsonContent = _jsonServices.Serialize(entities);
            return await _jsonServices.WriteFileAsync(_fileName, jsonContent);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entities = await GetAll();
            return entities.FirstOrDefault(e => e.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            var jsonContent = await _jsonServices.ReadFileAsync(_fileName);
            if (string.IsNullOrEmpty(jsonContent))
            {
                return new List<T>();
            }

            var entities = _jsonServices.Deserialize<List<T>>(jsonContent);
            return entities ?? new List<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entities = await GetAll();
            var entityToRemove = entities.FirstOrDefault(e => e.Id == id);

            if (entityToRemove == null)
            {
                Console.WriteLine($"Aviso: {typeof(T).Name} com ID '{id}' não encontrado para deleção. Considerado sucesso.");
                return true;
            }

            entities.Remove(entityToRemove);

            string jsonContent = _jsonServices.Serialize(entities);
            return await _jsonServices.WriteFileAsync(_fileName, jsonContent);
        }
    }
}