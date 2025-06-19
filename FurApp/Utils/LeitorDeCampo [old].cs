/*
using System;
using System.Threading.Tasks;
using MySqlConnector;
using Models.CamposApp;
using Models.CamposApp.Tipo;
using Repository.PersistenciaApp.CamposTipo;

namespace Utils.Pelase.Leitor.Campos
{
    public static class LeitorDeCampos
    {
        public static async Task<Campo> LerCampos(MySqlDataReader reader, RepositoryCamposTipos repoTipoCampos)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (repoTipoCampos == null) throw new ArgumentNullException(nameof(repoTipoCampos));

            string nome = reader.GetString("Nome");
            string local = reader.GetString("Local");
            int capacidade = reader.GetInt32("Capacidade");

            Guid tipoDeCampoId = reader.GetGuid("TipoDeCampoId");

            TipoDeCampo? tipoDeCampo = await repoTipoCampos.GetByIdAsync(tipoDeCampoId);

            if (tipoDeCampo == null)
            {
                throw new InvalidOperationException(
                    $" ! Campo '{nome}' não pode ser encontrado com este '{tipoDeCampoId}' ! ");
            }

            var campo = new Campo(nome, local, capacidade, tipoDeCampo);

            typeof(Campo).GetProperty("Id")?.SetValue(campo, reader.GetGuid("Id"));

            return campo;
        }
    }
}
*/