using System;
using MySqlConnector;
using Models.CamposApp;

namespace Utils.Pelase.Argumentos.Campos
{
    public static class ArgumentosCampos
    {
        public static void PreencherParametros(MySqlCommand cmd, Campo campo)
        {
            cmd.Parameters.AddWithValue("@id", campo.Id.ToString());
            cmd.Parameters.AddWithValue("@nome", campo.Nome);
            cmd.Parameters.AddWithValue("@local", campo.Local);
            cmd.Parameters.AddWithValue("@capacidade", campo.Capacidade);
            cmd.Parameters.AddWithValue("@deletado", campo.Deletado);
            cmd.Parameters.AddWithValue("@dataDelecao", campo.DataDelecao.HasValue ? (object)campo.DataDelecao.Value.ToString("yyyy-MM-dd HH:mm:ss") : DBNull.Value);
            cmd.Parameters.AddWithValue("@quemDeletou", campo.QuemDeletou ?? (object)DBNull.Value);

            if (campo.TipoDeCampo == null)
            {
                throw new ArgumentException(" !  Erro ao preencher parametros de campo  ! ");
            }
            cmd.Parameters.AddWithValue("@tipoDeCampo", campo.TipoDeCampo);
        }
    }
}