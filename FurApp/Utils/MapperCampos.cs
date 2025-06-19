using System;
using DTO.Campos;
using Models.CamposApp;

namespace Utils.Mappers.Campos
{
    public static class MapperCampos
    {
        public static CamposDTO ToCamposDTO(Campo campo)
        {
            if (campo == null)
            {
                throw new ArgumentNullException(nameof(campo), " ! O objeto campo não pode ser nulo para mapear o campo ! ");
            }

            if (campo.TipoDeCampo == null)
            {
                throw new InvalidOperationException(" ! Campo.TipoDeCampo é nulo. Certifique-se de que o TipoDeCampo foi carregado antes de mapear para DTO. ! ");
            }

            return new CamposDTO
            {
                Id = campo.Id,
                Nome = campo.Nome,
                Local = campo.Local,
                Capacidade = campo.Capacidade,
                TipoDeCampoId = campo.TipoDeCampo.Id,
                TipoDeCampoNome = campo.TipoDeCampo.Tipo
            };
        }
    }
}