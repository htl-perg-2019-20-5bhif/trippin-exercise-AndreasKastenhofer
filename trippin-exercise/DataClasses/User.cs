using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace trippin_exercise.DataClasses
{
    public class User
    {
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName
        {
            get; set;
        }
        [JsonPropertyName("Emails")]
        public IEnumerable<string> Emails { get; set; }

        [JsonPropertyName("AddressInfo")]
        public IEnumerable<AddressInfo> AddressInfo { get; set; }

        public User(UserFromFile user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;

            this.Emails = new List<string>() { user.Email };

            this.AddressInfo = new List<AddressInfo>()
                { new AddressInfo(user.Address, new City(user.CityName, user.Country, "")) };
        }
    }
}
