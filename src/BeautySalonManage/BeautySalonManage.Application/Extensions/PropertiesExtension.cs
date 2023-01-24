using System.ComponentModel.DataAnnotations;

namespace BeautySalonManage.Application.Extensions
{
    public static class PropertiesExtension
    {
        public static string GetDisplayName<T>(this T model, string nameProperty) where T : class
        {
            var type = typeof(T);

            object[] attrs = type.GetProperty(nameProperty).GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attrs != null && attrs.Length > 0)
                return ((DisplayAttribute)attrs[0]).Name;

            return nameProperty;
        }

        public static int GetNumberPageTotal(this int count, int pageSize)
        {
            if (count > 0)
            {
                if (count < pageSize) return 1;

                return (int)Math.Round(Convert.ToDecimal(count) / pageSize, 0, MidpointRounding.ToPositiveInfinity);
            }

            return 0;
        }
    }
}
