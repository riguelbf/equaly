using System.ComponentModel;
using DKO.EQualy.Domain.Interfaces.Helpers;

namespace DKO.EQualy.CustomHelpers
{
    public class EnumHelper : IEnumHelper
    {
        public string ObterDescricaoDoEnum(System.Enum enumValor)
        {
            var fi = enumValor.GetType().GetField(enumValor.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumValor.ToString();
        }
    }
}