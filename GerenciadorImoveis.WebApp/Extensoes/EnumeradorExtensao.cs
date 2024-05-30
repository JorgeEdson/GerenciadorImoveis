using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciadorImoveis.WebApp.Extensoes
{
    public static class EnumeradorExtensao
    {
        public static IEnumerable<SelectListItem> ToSelectList<TEnum>()
        where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum deve ser um enumerador.");
            }

            return Enum.GetValues(typeof(TEnum))
                .Cast<Enum>()
                .Select(e => new SelectListItem
                {
                    Text = e.ToString(),
                    Value = (Convert.ToInt32(e)).ToString()
                });
        }
    }
}
