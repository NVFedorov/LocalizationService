using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationService.Tests.Mock
{

    public class DataSourceMock : ILocalizationService
    {
        private readonly Dictionary<string, Dictionary<string, string>> localizations = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "en-US", new Dictionary<string, string>
                {
                    { "key1", "DataSourceMock_value1" },
                    { "key2", "DataSourceMock_value2" },
                    { "key3", "DataSourceMock_value3" },
                    { "key4", "DataSourceMock_value4" },
                    { "key5", "DataSourceMock_value5" }
                }
            },
            {
                "ru-RU", new Dictionary<string, string>
                {
                    { "key1", "DataSourceMock_значение1" },
                    { "key2", "DataSourceMock_значение2" },
                    { "key3", "DataSourceMock_значение3" },
                    { "key4", "DataSourceMock_значение4" },
                    { "key5", "DataSourceMock_значение5" }
                }
            },
            {
                "de-DE", new Dictionary<string, string>
                {
                    { "key1", "DataSourceMock_wert1" },
                    { "key2", "DataSourceMock_wert2" },
                    { "key3", "DataSourceMock_wert3" },
                    { "key4", "DataSourceMock_wert4" },
                    { "key5", "DataSourceMock_wert5" }
                }
            }
        }; 

        public string GetString(string key, CultureInfo culture)
        {
            return this.localizations[culture.Name][key];
        }


    }
}
