using Galytix.Models;

namespace Galytix.Services
{
    public interface ICountryGwpRepository
    {
        Task<List<CountryGwpCsvData>> GetAllCountryGwpDataAsync();
    }

}
