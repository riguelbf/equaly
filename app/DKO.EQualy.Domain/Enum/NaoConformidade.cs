using System.ComponentModel;

namespace DKO.EQualy.Domain.Enum
{
    public class NaoConformidade
    {
        public enum Status
        {
            [Description("Em descrição")]
            EmDescricao = 1,
            [Description("Aguardando aprovação")]
            AguardandoAprovacao = 2,
            [Description("Analisando causas")]
            AnalisandoCausas = 3,
            [Description("Em elaboração de plano de ação")]
            ElaborandoPlanoAcao = 4,
            [Description("Plano de ação em execução")]
            PlanoEmExecucao = 5 ,
            [Description("Verificando eficácia")]
            VerificandoEficacia = 6,
            [Description("Em padronização")]
            Padronizacao = 7,
            [Description("Finalizada")]
            Finalizada = 8,
            [Description("Cancelada")]
            Cancelada = 9
        }

        public enum TipoDePlanoDeAcao
        {
            [Description("Corretiva")]
            Corretiva = 1,
            [Description("Preventiva")]
            Preventiva = 2,
            [Description("Imediata")]
            Imediata = 3,
            [Description("Outro")]
            Outro = 4
        }

        public enum StatusPlanoDeAcao
        {
            [Description("Concluído")]
            Concluido = 1,
            [Description("Aberto")]
            Aberto = 2,
            [Description("Atrasado")]
            Atrasado = 3
        }
    }
}