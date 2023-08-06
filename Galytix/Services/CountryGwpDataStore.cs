using Galytix.Models;

namespace Galytix.Services
{
    public class CountryGwpDataStore
    {
        private readonly ICountryGwpRepository _countryGwpRepository;
        private List<CountryGwpCsvData> _countryGwpData;

        public CountryGwpDataStore(ICountryGwpRepository countryGwpRepository)
        {
            _countryGwpRepository = countryGwpRepository;
        }

        public async Task InitializeDataAsync()
        {
            _countryGwpData = await _countryGwpRepository.GetAllCountryGwpDataAsync();
        }
        public IEnumerable<CountryGwpCsvData> GetCountryGwpForLinesOfBusiness(string country, List<string> linesOfBusiness, List<CountryGwpCsvData> csvRecords)
        {
            var selectedGwps = csvRecords
                .Where(g => g.country == country && linesOfBusiness.Contains(g.lineOfBusiness));

            return selectedGwps;
        }
    }
}
