using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleWebClient
{
    class MyIngredient
    {
        public Array Details { get; set; }
    }
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {

            client.BaseAddress = new Uri("https://localhost:44379/api/");
            client.DefaultRequestHeaders.Add("User-Agent", "C# Console Programme");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "Ingredients";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var ingredients = JsonConvert.DeserializeObject<List<Rootobject>>(result);

            foreach (var item in ingredients)
            {
                foreach (var ingredient in item.data.ingredients)
                {
                    Console.WriteLine(ingredient.id);
                }
            }
            

            
        }

    }
}
