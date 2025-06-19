/*
using System;
using Interfaces.IDatabase;
using MySqlConnector;
using Repository.Database.Jogadores;

namespace Repository.Database.Gerenciamento
{
    public class DatabaseGerenciamento
    {
        private readonly string _connStr;
        private readonly List<IDatabase> _tabelas;

        public DatabaseGerenciamento(string connStr)
        {
            _connStr = connStr;
            _tabelas = new List<IDatabase>
            {
                new DatabaseJogadores()
            };
        }

        public async Task InicializarTabelaAsync()
        {
            using var conn = new MySqlConnection(_connStr);
            await conn.OpenAsync();

            foreach (var tabela in _tabelas)
            {
                await tabela.CriarTabelaAsync(conn);
            }
        }
    }
}
*/