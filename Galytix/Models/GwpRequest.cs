using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Galytix
{
    public class GwpRequest
    {
        public string country { get; set; }
        public List<string> lob { get; set; }
        public IFormFile CsvFile { get; set; }
    }
}
