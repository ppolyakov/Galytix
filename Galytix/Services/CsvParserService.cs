using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Galytix.Models;

namespace Galytix.Services
{
    public class CsvParser : ICsvParser
    {
        public async Task<List<CountryGwpCsvData>> ParseCsvFile(Stream fileStream)
        {
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var csvRecords = new List<CountryGwpCsvData>();
                await foreach (var record in csv.GetRecordsAsync<CountryGwpCsvData>())
                {
                    csvRecords.Add(record);
                }
                return csvRecords;
            }
        }

        public List<CountryGwpCsvData> ParseCsvData(string csvData)
        {
            using (var reader = new StringReader(csvData))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var csvRecords = new List<CountryGwpCsvData>();
                csvRecords.AddRange(csv.GetRecords<CountryGwpCsvData>());
                return csvRecords;
            }
        }
    }

}
