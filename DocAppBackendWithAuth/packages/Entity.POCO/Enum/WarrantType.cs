using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO.Enum
{
    /// <summary>
    /// Тип ордера
    /// </summary>
    public enum WarrantType
    {
        /// <summary>
        /// Уголовный
        /// </summary>
        [Description("Уголовный")]
        Criminal = 1,
        /// <summary>
        /// Гражданский
        /// </summary>
        [Description("Гражданский")]
        Civil = 2
    }

    /// <summary>
    /// Расширение для перечисление результатов проверки сборки
    /// </summary>
    public static class WarrantTypeExtension
    {
        /// <summary>
        /// Получаем из атрибута описание данного результата проверки
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetAttrName(this WarrantType element)
        {
            var type = typeof(WarrantType);
            var memInfo = type.GetMember(element.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (!attributes.Any())
            {
                throw new Exception(String.Format("Элемент перечисления {0} не имеет атрибута  DescriptionAttribute", element.ToString()));
            }
            return ((DescriptionAttribute)attributes[0]).Description;
        }

        /// <summary>
        /// Получаем коллекцию всех возможных результатов проверки сборки
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<int, string>> GetAll(this WarrantType element)
        {
            var collection = (IEnumerable<WarrantType>)System.Enum.GetValues(typeof(WarrantType));
            return collection.Select(t => new KeyValuePair<int, string>((int)t, t.GetAttrName()));
        }
    }
}
