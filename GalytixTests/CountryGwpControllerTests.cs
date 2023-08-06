using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Text;
using Galytix;

namespace GalytixTests
{
    public class CountryGwpControllerTests : IClassFixture<WebApplicationFactory<Galytix.Program>>
    {
        private readonly WebApplicationFactory<Galytix.Program> _factory;

        public CountryGwpControllerTests(WebApplicationFactory<Galytix.Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAverageGwp_ReturnsOkResult()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new GwpRequest
            {
                country = "ae",
                lob = new List<string>() { "property", "transport" }
            };

            var csvFileContent = "country,variableId,variableName,lineOfBusiness,Y2000,Y2001,Y2002,Y2003,Y2004,Y2005,Y2006,Y2007,Y2008,Y2009,Y2010,Y2011,Y2012,Y2013,Y2014,Y2015\r\n" +
                                "ae,gwp,Direct,Premiums,transport,,,,,,,,231441262.7,268744928.7,284448918.2,314413884.1,327740154.4,326126300.6,240322742.6,234164748.7,\r\n" +
                                "ae,gwp,Direct,Premiums,property,,,,,,,,422555207.6,446001906.1,581850238.3,617352212.4,684477603.8,658736555.5,593685815.4,611083582.9,";
            var fileContent = Encoding.UTF8.GetBytes(csvFileContent);
            var fileStream = new MemoryStream(fileContent);
            var formFile = new FormFile(fileStream, 0, fileStream.Length, "CsvFile", "data.csv");

            request.CsvFile = formFile;

            // Act
            var response = await client.PostAsync("http://localhost:9091/server/api/CountryGwp/avg", new MultipartFormDataContent
    {
        { new StringContent(request.country), "country" },
        { new StringContent(string.Join(",", request.lob)), "lob" },
        { new StreamContent(formFile.OpenReadStream()), "csvFile", "data.csv" }
    });

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);

        }
    }
}