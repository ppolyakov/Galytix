using Microsoft.AspNetCore.Mvc;
using Galytix.Services;

namespace Galytix
{
    [ApiController]
    [Route("server/api/[controller]")]
    public class CountryGwpController : ControllerBase
    {
        private readonly CountryGwpDataStore _dataStore;
        private readonly ICsvParser _csvParser;

        public CountryGwpController(CountryGwpDataStore dataStore, ICsvParser csvParser)
        {
            _dataStore = dataStore;
            _csvParser = csvParser;
        }

        [HttpPost("avg")]
        public async Task<IActionResult> GetAverageGwp([FromForm] GwpRequest request)
        {
            // Parse CSV data from the uploaded file
            var csvRecords = await _csvParser.ParseCsvFile(request.CsvFile.OpenReadStream());

            // Parse CSV data from the string if you receive CSV data as a string
            // var csvRecords = _csvParser.ParseCsvData(csvDataString);

            var selectedGwps = _dataStore.GetCountryGwpForLinesOfBusiness(request.country, request.lob, csvRecords);
            if (selectedGwps == null || !selectedGwps.Any())
            {
                return NotFound("Data not found for the selected country and lines of business.");
            }

            var averageGwpsByLob = new Dictionary<string, decimal?>();
            foreach (var lineOfBusiness in request.lob)
            {
                var gwpsForLineOfBusiness = selectedGwps
                    .Where(g => g.lineOfBusiness == lineOfBusiness)
                    .Select(c => new decimal?[] { c.Y2008, c.Y2009, c.Y2010, c.Y2011, c.Y2012, c.Y2013, c.Y2014, c.Y2015 })
                    .Select(avgValues => avgValues.Where(val => val.HasValue))
                    .Where(avgValues => avgValues.Any())
                    .Select(avgValues => avgValues.Average());

                if (gwpsForLineOfBusiness.Any())
                {
                    decimal? result = gwpsForLineOfBusiness.FirstOrDefault().HasValue
                       ? (decimal?)Math.Round(gwpsForLineOfBusiness.FirstOrDefault().Value, 1)
                       : null;

                    averageGwpsByLob[lineOfBusiness] = result;
                }
                else
                {
                    averageGwpsByLob[lineOfBusiness] = 0;
                }
            }

            return Ok(averageGwpsByLob);
        }
    }
}


