using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationService.Tests.Mock
{
    public class DataBaseMock : ILocalizationService
    {
        private readonly List<(string Culture, string Key, string Text)> localizationsTableMock = new List<(string Culture, string Key, string Text)>();

        public DataBaseMock()
        {
            this.localizationsTableMock.Add((Culture: "en-US", Key: "DataBaseMock_key1", Text: "DataBaseMock_value1"));
            this.localizationsTableMock.Add((Culture: "en-US", Key: "DataBaseMock_key2", Text: "DataBaseMock_value2"));
            this.localizationsTableMock.Add((Culture: "ru-RU", Key: "DataBaseMock_key1", Text: "DataBaseMock_значение1"));
            this.localizationsTableMock.Add((Culture: "ru-RU", Key: "DataBaseMock_key2", Text: "DataBaseMock_значение2"));
            this.localizationsTableMock.Add((Culture: "de-DE", Key: "key1", Text: "DataBaseMock_wert1"));
            this.localizationsTableMock.Add((Culture: "de-DE", Key: "key2", Text: "DataBaseMock_wert2"));
        }

        public string GetString(string key, CultureInfo culture)
        {
            return this.SelectResourceFromTable(key, culture.Name);
        }

        private string SelectResourceFromTable(string key, string locale)
        {
            var localization = this.localizationsTableMock.FirstOrDefault(x => x.Culture == locale && x.Key == key);
            return localization.Text;
        }
    }
}
