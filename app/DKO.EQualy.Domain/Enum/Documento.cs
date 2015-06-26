namespace DKO.EQualy.Domain.Enum
{
    public class Documento
    {
        public enum FaseDocumento
        {
            Solicitacao = 1,
            Elaboracao = 2,
            Revisao = 3,
            Aprovacao = 4,
            Publicacao = 5,
            Reprovacao = 6,
            Disponibilizado = 7
        }
        public enum TipoDeArmazenamento
        {
            Digital = 1,
            Fisico = 2
        }

        public enum TipoDocumento
        {
            Documento = 1,
            Registro = 2
        }

        public enum TipoDeDescarte
        {
            Picotar = 1
        }
    }
}