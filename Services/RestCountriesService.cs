using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using EvaluacionP3DiazDaniel.Models;

namespace EvaluacionP3DiazDaniel.Services
{
    public class RestCountriesService
    {
        private const string BaseUrl = "https://restcountries.com/v3.1/name/{name}";

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUrl}{name}?fields=name,region,maps");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<dynamic>();
                if (data != null && data.Count > 0)
                {
                    return new Country
                    {
                        Name = data[0].name.common,
                        Region = data[0].region,
                        GoogleMapsLink = data[0].maps.googleMaps
                    };
                }
            }
            return null;
        }
    }
}
