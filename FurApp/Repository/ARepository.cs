using System;
using System.Collections.Generic;
using System.IO; // Embora não usado diretamente, pode ser necessário para outras extensões
using System.Linq;
using System.Threading.Tasks;
using Interfaces.IRepository;
using Services.Json; // Certifique-se de que este é o namespace correto para JsonServices
using Models; // Certifique-se de que este é o namespace correto para AModel

namespace Repository.PersistenciaApp
{
    public abstract class ARepository<T> : IRepository<T>
        where T : AModel // Garante que T tem a propriedade Id do tipo Guid
    {
        protected readonly JsonServices _jsonServices;
        protected readonly string _fileName; // Armazena apenas o nome do arquivo (ex: "posicoes.json")

        public ARepository(JsonServices jsonServices, string fileName)
        {
            // Validações básicas para garantir que as dependências não são nulas ou vazias
            _jsonServices = jsonServices ?? throw new ArgumentNullException(nameof(jsonServices));
            _fileName = !string.IsNullOrWhiteSpace(fileName)
                ? fileName
                : throw new ArgumentException("O nome do arquivo não pode ser nulo ou vazio.", nameof(fileName));
        }

        /// <summary>
        /// Salva uma entidade (adiciona se nova, atualiza se existente) na coleção e a persiste.
        /// Este método verifica a existência pelo Id da entidade.
        /// </summary>
        /// <param name="entity">A entidade a ser salva.</param>
        /// <returns>True se a operação foi bem-sucedida, false caso contrário.</returns>
        public async Task<bool> SalvarAsync(T entity)
        {
            if (entity == null)
            {
                Console.WriteLine($"Erro: O objeto {typeof(T).Name} não pode ser nulo ao salvar.");
                return false;
            }

            // Carrega todas as entidades existentes
            var entities = await GetAll();

            // Tenta encontrar a entidade existente pelo ID
            var existingEntity = entities.FirstOrDefault(e => e.Id == entity.Id);

            if (existingEntity != null)
            {
                // Se a entidade já existe, a substitui na lista
                var index = entities.IndexOf(existingEntity);
                if (index != -1) // Garante que o índice foi encontrado (deve ser)
                {
                    entities[index] = entity;
                }
                else
                {
                    // Fallback, caso a entidade encontrada não esteja na lista pelo IndexOf
                    Console.WriteLine($"Aviso: Entidade existente com ID '{entity.Id}' não encontrada na lista para substituição. Adicionando como nova.");
                    entities.Add(entity); // Adiciona como nova se não conseguir substituir
                }
            }
            else
            {
                // Se a entidade não existe, a adiciona à lista
                entities.Add(entity);
            }

            // Serializa a lista completa e escreve no arquivo usando JsonServices
            string jsonContent = _jsonServices.Serialize(entities);
            // JsonServices agora é responsável por combinar _baseDirectory e _fileName
            return await _jsonServices.WriteFileAsync(_fileName, jsonContent);
        }

        /// <summary>
        /// Obtém uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser buscada.</param>
        /// <returns>A entidade encontrada ou null se não existir.</returns>
        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entities = await GetAll();
            return entities.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Obtém todas as entidades do arquivo JSON.
        /// </summary>
        /// <returns>Uma lista de todas as entidades, ou uma lista vazia se o arquivo não existir ou estiver vazio.</returns>
        public async Task<List<T>> GetAll() // Mantido o nome GetAll conforme sua preferência
        {
            // JsonServices agora é responsável por ler o arquivo, combinando _baseDirectory e _fileName
            var jsonContent = await _jsonServices.ReadFileAsync(_fileName);
            if (string.IsNullOrEmpty(jsonContent))
            {
                return new List<T>();
            }

            var entities = _jsonServices.Deserialize<List<T>>(jsonContent);
            return entities ?? new List<T>(); // Retorna lista vazia se a desserialização resultar em null
        }

        /// <summary>
        /// Deleta uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser deletada.</param>
        /// <returns>True se a deleção foi bem-sucedida ou se a entidade não existia, false em caso de erro.</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entities = await GetAll();
            var entityToRemove = entities.FirstOrDefault(e => e.Id == id);

            if (entityToRemove == null)
            {
                Console.WriteLine($"Aviso: {typeof(T).Name} com ID '{id}' não encontrado para deleção. Considerado sucesso.");
                return true; // Considera como sucesso se o item já não existia
            }

            entities.Remove(entityToRemove);

            // Serializa a lista atualizada e escreve no arquivo usando JsonServices
            string jsonContent = _jsonServices.Serialize(entities);
            // JsonServices agora é responsável por combinar _baseDirectory e _fileName
            return await _jsonServices.WriteFileAsync(_fileName, jsonContent);
        }
    }
}