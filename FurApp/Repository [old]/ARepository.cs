/*
using System;
using System.Collections.Generic;
using MySqlConnector;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Interfaces.old.IRepository;
using System.Data;

namespace Repository.PersistenciaApp
{
    public abstract class ARepository<T> : IRepository<T>, IDisposable where T : class
    {
        private bool _disposed = false;
        protected readonly string _connStr;
        protected ARepository(string? connStr = null)
        {
            _connStr = connStr ?? ConectarPorPadrao();
        }
        private static string ConectarPorPadrao()
        {
            throw new InvalidOperationException("A string de conexão deve ser fornecida explicitamente ou configurada via IConfiguration.");
        }

        public MySqlConnection Conectar()
        {
            return new MySqlConnection(_connStr);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                { }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var conn = Conectar())
            {
                await conn.OpenAsync();
                throw new NotImplementedException();
            }
        }
        
        public async Task<T> GetByIdAsync(int id)
        {
            using (var conn = Conectar())
            {
                await conn.OpenAsync();
                throw new NotImplementedException();
            }
        }

        public abstract Task<T?> GetByNameAsync(string nome);
        public async Task DeleteAsync(int id)
        {
            using (var conn = Conectar())
            {
                await conn.OpenAsync();
                throw new NotImplementedException();
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            using (var conn = Conectar())
            {
                await conn.OpenAsync();
                throw new NotImplementedException();
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            using (var conn = Conectar())
            {
                await conn.OpenAsync();
                throw new NotImplementedException();
            }
        }
    }
}
*/