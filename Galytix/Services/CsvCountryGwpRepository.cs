using CsvHelper;
using Galytix.Models;

namespace Galytix.Services
{
    public class CsvCountryGwpRepository : ICountryGwpRepository
    {
        private readonly ICsvParser _csvParser;

        public CsvCountryGwpRepository(ICsvParser csvParser)
        {
            _csvParser = csvParser;
        }

        public async Task<List<CountryGwpCsvData>> GetAllCountryGwpDataAsync()
        {
            // Read CSV data from the file or any other data source
            using (var stream = File.OpenRead("your-csv-file-path.csv"))
            {
                return await _csvParser.ParseCsvFile(stream);
            }
        }
    }

}
