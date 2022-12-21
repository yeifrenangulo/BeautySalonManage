using System.ComponentModel.DataAnnotations;

namespace BeautySalonManage.Application.Utilities
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
    }
}
