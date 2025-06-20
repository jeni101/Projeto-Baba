using System;
using System.Text.Json.Serialization;

namespace Models.CamposApp.Tipo
{
    public class TipoDeCampo : AModel
    {
        public string Tipo { get; set; }
        public int CapacidadePadrao { get; set; }

        public TipoDeCampo()
            : base ()
        {
            Tipo = string.Empty;
            CapacidadePadrao = 0;
        }

        public TipoDeCampo(string tipo, int capacidadePadrao) : this()
        {
            Tipo = tipo;
            CapacidadePadrao = capacidadePadrao;
        }

        public TipoDeCampo(Guid id, string tipo, int capacidadePadrao)
        {
            Id = id;
            Tipo = tipo;
            CapacidadePadrao = capacidadePadrao;
        }
    }
}