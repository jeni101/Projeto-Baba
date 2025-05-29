using System;
using DTO.Perfil.Usuario;
using Models.ContaApp.Usuario;

namespace Presentation.Perfil
{
    public static class PresenterPerfil
    {
        public static void ExibirPerfil(PerfilUsuarioDTO perfilDTO)
        {
            if (perfilDTO == null)
            {
                Console.WriteLine("Erro: Não foi possível exibir o perfil. DTO nulo");
                return;
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine($"=== PERFIL DE {perfilDTO.Nome.ToUpper()} ===");
            Console.WriteLine("========================================");
            Console.WriteLine($"ID: {perfilDTO.Id}");
            Console.WriteLine($"Tipo: {perfilDTO.TipoConta}");
            Console.WriteLine($"Idade: {perfilDTO.Idade} anos");
            Console.WriteLine($"Saldo: R$ {perfilDTO.Saldo:F2}");
            Console.WriteLine($"Membro desde: {perfilDTO.DataCriacao:dd/MM/yyyy}");
            Console.WriteLine($"Interesses: {perfilDTO.Interesses}");
            Console.WriteLine($"Amistosos: {perfilDTO.Amistosos}");
            Console.WriteLine($"Time Associado: {perfilDTO.TimeAssociado}");
            Console.WriteLine("========================================\n");
        }
    }
}