using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;
namespace Galytix
{
    public class DecimalConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null; // Return null for empty or whitespace values
            }

            if (decimal.TryParse(text, out decimal result))
            {
                return result;
            }

            return null;
        }
    }

}
