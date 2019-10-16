using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace trippin_exercise.DataClasses
{
    public class AddressInfo
    {
        public AddressInfo(string Address, City City)
        {
            this.Address = Address;
            this.City = City;
        }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("City")]
        public City City { get; set; }
    }
}
