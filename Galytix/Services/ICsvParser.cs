using Galytix.Models;

namespace Galytix
{
    public interface ICsvParser
    {
        Task<List<CountryGwpCsvData>> ParseCsvFile(Stream fileStream);
        List<CountryGwpCsvData> ParseCsvData(string csvData);
    }

}
