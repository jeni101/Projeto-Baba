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
                //Tem que testar ainda, provavelmente está bem desorganizado no print, Se alguem puder deixar um jeito de eu ver como fica no program eu agradeço
            Console.WriteLine($" .________________________ Perfil De: ________________________.");
            Console.WriteLine($" | -=-             {perfilDTO.Nome.ToUpper()}             -=- |");
            Console.WriteLine($" |============================================================|");
            Console.WriteLine($" |- ID: {perfilDTO.Id}                                        |");
            Console.WriteLine($" |- Tipo: {perfilDTO.TipoConta}                               |");
            Console.WriteLine($" |- Idade: {perfilDTO.Idade} anos                             |");
            Console.WriteLine($" |- Saldo: R$ {perfilDTO.Saldo:F2}                            |");
            Console.WriteLine($" |- Membro desde: {perfilDTO.DataCriacao:dd/MM/yyyy}          |");
            Console.WriteLine($" |- Interesses: {perfilDTO.Interesses}                        |");
            Console.WriteLine($" |- Amistosos: {perfilDTO.Amistosos}                          |");
            Console.WriteLine($" |- Time Associado: {perfilDTO.TimeAssociado}                 |");
            Console.WriteLine($" |____________________________________________________________|");
            Console.WriteLine($" |============================================================|");
        }
    }
}