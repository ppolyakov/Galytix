using CsvHelper.Configuration.Attributes;

namespace Galytix.Models
{
    public class CountryGwpCsvData
    {

        public string country { get; set; } = string.Empty;
        public string variableId { get; set; } = string.Empty;
        public string variableName { get; set; } = string.Empty;
        public string lineOfBusiness { get; set; } = string.Empty;
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2000 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2001 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2002 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2003 { get; set; }

        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2004 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2005 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2006 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2007 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2008 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2009 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2010 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2011 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2012 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2013 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2014 { get; set; }
        [TypeConverter(typeof(DecimalConverter))]
        public decimal? Y2015 { get; set; }

    }
}

