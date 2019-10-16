using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace trippin_exercise.DataClasses
{
    public class City
    {
        public City(string cityName, string countryRegion, string region)
        {
            this.Name = cityName;
            this.CountryRegion = countryRegion;
            this.Region = region;
        }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("CountryRegion")]
        public string CountryRegion { get; set; }

        [JsonPropertyName("Region")]
        public string Region { get; set; }
    }
}
