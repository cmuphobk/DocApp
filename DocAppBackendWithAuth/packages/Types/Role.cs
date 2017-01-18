using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DocAppBackendWithAuth.Common.Types
{
    /// <summary>
    /// Роли
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Администратор адвокатской палаты
        /// </summary>
        [Description("Ответственный по адвокатской палате")]
        Admin = 1,

        /// <summary>
        /// Менеджер адвокатской палаты - заполняет справочники
        /// </summary>
        [Description("Менеджер адвокатской палаты")]
        Manager = 2,

        /// <summary>
        /// Адвокат
        /// </summary>
        [Description("Адвокат")]
        Lawyer = 3,

        /// <summary>
        /// Ответственный в адвокатском образовании
        /// </summary>
        [Description("Ответственный по адвокатскому образованию")]
        CompanyChief = 5,

        /// <summary>
        /// Оператор в адвокатском образовании
        /// </summary>
        [Description("Оператор адвокатского образования")]
        CompanyOperator = 6,

        /// <summary>
        /// Главный бухгалтер в адвокатском образовании
        /// </summary>
        [Description("Главный бухгалтер адвокатского образования")]
        CompanyMainAccounter = 7,
        /// <summary>
        /// Аудитор адвокатского образования
        /// </summary>
        [Description("Аудитор адвокатского образования")]
        CompanyAuditor = 8,

        /// <summary>
        /// Ответственный по судебному району
        /// </summary>
        [Description("Ответственный по судебному району")]
        ZoneChief = 9,

    }

    /// <summary>
    /// Расширение для перечисление результатов проверки сборки
    /// </summary>
    public static class CompanyTypeExtension
    {
        /// <summary>
        /// Получаем из атрибута описание данного результата проверки
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetAttrName(this Role element)
        {
            var type = typeof(Role);
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
        public static IEnumerable<KeyValuePair<int, string>> GetAll(this Role element)
        {
            var collection = (IEnumerable<Role>)System.Enum.GetValues(typeof(Role));
            return collection.Select(t => new KeyValuePair<int, string>((int)t, t.GetAttrName()));
        }
    }
}
