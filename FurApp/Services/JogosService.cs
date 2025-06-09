using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySqlConnector;
using Models.JogosApp;
using Models.CamposApp;
using Repository.PersistenciaApp.Campos;
using Repository.PersistenciaApp.Jogos;

namespace Services.Jogos
{
    public class JogosServices
    {
        private readonly RepositoryCampos _repoCampos = new RepositoryCampos();
        private readonly RepositoryJogo _repoJogo = new RepositoryJogo();

        public async Task<Campo?> SelecionarCampoDisponível(DateOnly data, TimeOnly hora)
        {
            var campo = await Jogo.SelecionarCampo(_repoCampos);
            if (campo == null) return null;

            if (await _repoCampos.VerificarDisponibilidade(campo.Id, data, hora))
            {
                return campo;
            }

            Console.WriteLine($"{campo.Nome} já reservado");
            Console.WriteLine("Deseja tentar outro campo? (S/N): ");

            return Console.ReadLine()?.Trim().ToUpper() == "S"
                ? await SelecionarCampoDisponível(data, hora)
                : null;
        }

        public int ObterQuantidadeDeJogadores(int capacidadeCampo)
        {
            while (true)
            {
                Console.Write($"Quantidade de jogadores (máx {capacidadeCampo}): ");
                
                if (int.TryParse(Console.ReadLine(), out int quantidade))
                {
                    if (quantidade < 1)
                    {
                        Console.WriteLine("A quantidade deve ser pelo menos 1");
                        continue;
                    }
                    
                    if (quantidade > capacidadeCampo)
                    {
                        Console.WriteLine($"Aviso: Capacidade máxima é {capacidadeCampo}");
                        Console.Write("Deseja continuar mesmo assim? (S/N): ");
                        
                        if (Console.ReadLine()?.Trim().ToUpper() == "S")
                            return quantidade;
                    }
                    else
                    {
                        return quantidade;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido");
                }
            }
        }

        public async Task<bool> PersistirJogo(Jogo jogo)
        {
            try
            {
                if (jogo == null)
                {
                    Console.WriteLine("Erro: O objeto Jogo a ser persistido não pode ser nulo.");
                    return false;
                }
                return await _repoJogo.SalvarJogos(jogo);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}