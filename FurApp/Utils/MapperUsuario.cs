using System;
using System.Linq;
using DTO.Perfil.Usuario;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;

namespace Utils.Mappers.Usuario
{
    public static class MapperUsuario
    {
        public static PerfilUsuarioDTO ToPerfilUsuarioDTO(Conta_Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "O objeto usuário não pode ser nulo para mapear o perfil");
            }

            string tiposConta = "";
            if (usuario.TornouSeJogador)
            {
                tiposConta += "Jogador";
            }
            if (usuario.TornouSeTecnico)
            {
                if (!string.IsNullOrEmpty(tiposConta)) tiposConta += " e ";
                tiposConta += "Tecnico";
            }
            if (string.IsNullOrEmpty(tiposConta)) tiposConta = "Nenhum tipo de conta defino";

            string interessesFormatados = usuario.Interesses != null && usuario.Interesses.Any()
                ? string.Join(", ", usuario.Interesses)
                : "Nenhum";

            string timeAssociado = "Nenhum";
            if (usuario is Conta_Tecnico tecnico)
            {
                timeAssociado = tecnico.TimeTecnico?.Nome ?? "Nenhum";
            }

            return new PerfilUsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                TipoConta = tiposConta,
                Idade = usuario.Idade,
                DataCriacao = usuario.DataCriacao,
                Interesses = interessesFormatados,
                TimeAssociado = timeAssociado
            };
        }
    }
}