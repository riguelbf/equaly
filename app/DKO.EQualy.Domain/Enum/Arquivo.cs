using System.ComponentModel;

namespace DKO.EQualy.Domain.Enum
{
    public class Arquivo
    {
        public enum Tipo
        {
            [Description("Foto do usuário")]
            FotoUsuario,
            
            [Description("Excel")]
            Excel,
            
            [Description("Word")]
            Word,
            
            [Description("PDF")]
            PDF,
            
            [Description("Txt")]
            TXT,

            [Description("Fisico")]
            Fisico,

            [Description("Outro")]
            Outro,
        } 
    }
}