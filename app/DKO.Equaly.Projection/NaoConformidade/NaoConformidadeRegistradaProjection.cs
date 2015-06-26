using System;

namespace DKO.Equaly.Projection.NaoConformidade
{
    public class NaoConformidadeRegistradaProjection
    {
        public int Codigo { get; set; }
        public DateTime DataAbertura { get; set; }
        public string NomeReclamante { get; set; }
        public string TelefoneReclamante { get; set; }
        public string NomeResponsavelAbertura { get; set; }
        public string Status { get; set; }
        public string IndicadorPrazo { get; set; }
        public string Titulo { get; set; }
    }
}