namespace ContaJogadorApp;

interface IJogador
{
    void escolherPosicao();
    void adicionarPosicao();
    void removerPosicao();
    void entrarEmTime();
    void sairDoTime();
    void exibirGols();
    void ocultarGols();
    void exibirAssistencias();
    void ocuktarAssistencias();
    void exibirJogos();
    void ocultarJogos();
    void exibirPartidas();
    void ocultarPartidas();
}