using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalizationService
{
    public class LocalizationFactory
    {
        private static LocalizationFactory factory;
        private readonly List<ILocalizationService> registrations = new List<ILocalizationService>();

        private LocalizationFactory() { }

        public static LocalizationFactory GetInstance()
        {
            if (factory == null)
            {
                factory = new LocalizationFactory();
            }

            return factory;
        }

        public void Register<TImpl>() where TImpl : ILocalizationService
        {
            this.registrations.Add((ILocalizationService)Activator.CreateInstance(typeof(TImpl)));
        }

        public void Register(ILocalizationService instance)
        {
            this.registrations.Add(instance);
        }

        public string GetString(string key, CultureInfo culture = null)
        {
            var currentCulture = culture ?? Thread.CurrentThread.CurrentCulture;
            // если при получении строки от сервиса возникнет ошибка, упадет вся функция
            //var used = this.registrations.FirstOrDefault(x => !string.IsNullOrEmpty(x.GetString(key, culture)));
            var result = string.Empty;
            foreach (var reg in this.registrations)
            {
                // сервис локализации не отвечает за ошибки источников данных
                try
                {
                    result = reg.GetString(key, culture);
                }
                catch (Exception)
                {
                    // log warning
                }

                // это какой-то костыль... (реализация требования про пересечение ключей)
                // источник данных, в котором нашли ключ передвигаем вперед, чтобы искать в нем в первую очередь
                if (!string.IsNullOrEmpty(result))
                {
                    this.registrations.Remove(reg);
                    this.registrations.Insert(0, reg);
                    return result;
                }
            }

            return result;
        }
    }
}
