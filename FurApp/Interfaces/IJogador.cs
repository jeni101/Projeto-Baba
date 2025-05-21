using Models.PosicaoApp;
namespace Interfaces.IJogador;

interface IJogador
{
    void Escolher_Posicao(List<Posicao> posicoesDisponiveis);
    void Entrar_Time();
    void Exibir_Time();
    void Exibir_Gols();
    void Exibir_Assistencias();
    void Exibir_Jogos();
    void Exibir_Partidas();
}