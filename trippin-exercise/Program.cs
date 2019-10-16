using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using trippin_exercise.DataClasses;

namespace trippin_exercise
{
    class Program
    {
        private static HttpClient HttpClient
            = new HttpClient() { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/(S(14jcxmp2uz4ripbdncqmzfs1))/") };

        static async Task Main(string[] args)
        {
            // Read File
            IEnumerable<UserFromFile> users = await readJsonFileAsync();

            // Check if User exists
            await checkIfUserExists(users);
        }

        private static async Task checkIfUserExists(IEnumerable<UserFromFile> users)
        {
            foreach (var user in users)
            {
                var userResponse = await HttpClient.GetAsync("People('" + user.UserName + "')");

                if (!userResponse.IsSuccessStatusCode)
                {
                    // add User (post-request)
                    await postUserAsync(user);
                }
            }
        }

        private static async Task postUserAsync(UserFromFile user)
        {
            var content = new StringContent(JsonSerializer.Serialize(new User(user)), Encoding.UTF8, "application/json");
            var userPostResponse = await HttpClient.PostAsync("People", content);

            try
            {
                userPostResponse.EnsureSuccessStatusCode();
                Console.WriteLine("User " + user.UserName + " was inserted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while inserting user " + user.UserName);
            }
        }

        private static async Task<IEnumerable<UserFromFile>> readJsonFileAsync()
        {
            var file = await File.ReadAllTextAsync("users.json");
            IEnumerable<UserFromFile> users = JsonSerializer.Deserialize<IEnumerable<UserFromFile>>(file);
            return users;
        }
    }
}
