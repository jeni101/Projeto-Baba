using System;

namespace Models.CamposApp.Tipo
{
    public class TipoDeCampo
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public int CapacidadePadrao { get; set; }

        public TipoDeCampo(string tipo, int capacidadePadrao)
        {
            Tipo = tipo;
            CapacidadePadrao = capacidadePadrao;
        }
    }
}