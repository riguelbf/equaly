namespace DKO.EQualy.Domain.Enum
{
    public class Atividade
    {
        public enum StatusAtividade
        {
            Criada = 1,
            Pendente = 2,
            Atrasada = 3,
            Concluida = 4
        }

        public enum TipoAtividade
        {
            AprovacaoDocumento = 1,
            ElaboracaoDocumento = 2,
            Pontuar = 3,
            Lembrete = 4,
            RevisaoDocumento = 5,
            AjustarDocumento = 6
        }
    }
}