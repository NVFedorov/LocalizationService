using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationService
{
    // источник данных должен реализовывать этот интерфейс
    public interface ILocalizationService
    {
        string GetString(string key, CultureInfo culture);
    }
}
