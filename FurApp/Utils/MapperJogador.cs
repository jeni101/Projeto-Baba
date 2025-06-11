using DTO.Perfil.Usuario.Jogador;
using Models.ContaApp.Usuario.Jogador;

namespace Utils.Mappers.Jogadores {
    public static class MapperJogador
    {
        public static JogadorDTO ToJogadorDTO(Conta_Jogador jogador)
        {
            if (jogador == null)
            {
                throw new ArgumentNullException(nameof(jogador), " ! O objeto jogador não pode ser nulo para mapear o jogador ! ");
            }

            return new JogadorDTO
            {
                Id = jogador.Id,
                Nome = jogador.Nome ?? string.Empty,
                Idade = jogador.Idade,
                Posicao = jogador.Posicao ?? "Desconhecida",
                TimeAtual = jogador.Time,
                TipoConta = "Jogador",
                NomesJogosInteressados = jogador.Interesses ?? new List<string>(),
                NomePartidasJogadas = jogador.Partidas ?? new List<string>()
            };
        }
    }
}