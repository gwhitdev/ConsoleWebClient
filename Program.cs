using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using static System.Console;
using System.Diagnostics;

namespace ConsoleWebClient
{
        
    class Program
    {
        private static readonly HttpClient client = new HttpClient();


        static async Task Main()
        {
            WriteLine("Would you like to do?");
            WriteLine("Option (1): Get all ingredients");
            WriteLine("Option (2): Get named ingredients");

            string chosenOption = ReadLine().ToString();

            if (chosenOption == "1")
            {
                await GetIngredients("Ingredients");
            }

            if (chosenOption == "2")
            {
                Console.WriteLine("Please enter a food item name: ");
                string ingredientName = ReadLine().ToString().ToLower();
                try
                {
                    await GetIngredients($"Ingredients?name={ingredientName}");
                }
                catch (Exception ex)
                {
                    WriteLine("Sorry, that didn't work!");
                    WriteLine(ex.Message);
                }

                
            }
            WriteLine("Press any key to exit");
            ReadLine();

        }

        
        static async Task GetIngredients(string input)
        {
           
            client.BaseAddress = new Uri($"https://familymealsapi.azurewebsites.net/api/");
            WriteLine(client.BaseAddress);
            client.DefaultRequestHeaders.Add("User-Agent", "C# Console Programme");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var url = input;
            WriteLine("Creating connection with server...");
            HttpResponseMessage response = await client.GetAsync(url);
            WriteLine("Connected.");
            response.EnsureSuccessStatusCode();
            WriteLine("Status: " + response.StatusCode);

            WriteLine("Awaiting ingredients...");
            
            var result = await response.Content.ReadAsStringAsync();
                      
            var ingredients = JsonConvert.DeserializeObject<List<Rootobject>>(result);
          
            
            WriteLine($"Ingredients received!");
            WriteLine("-----");
            WriteLine();
            int count = 0;
            List <Ingredient> ingredientList = new List<Ingredient>();
            foreach (var item in ingredients)
            {
                

                foreach (var ingredient in item.data.ingredients)
                {
                    count++;
                    WriteLine("Id: " + ingredient.id);
                    WriteLine("Name: " + ingredient.details.name);
                    WriteLine("Quantity Type: " + ingredient.details.quantityType);
                    WriteLine("Quantity: " + ingredient.details.quantity);
                    WriteLine("Kept at: " + ingredient.details.keptAt);
                    WriteLine("Use by date: " + ingredient.details.useByDate);
                    WriteLine("-----");
                    WriteLine();
                }
            }
            WriteLine($"Received {count} ingredients.");

        }

    }
}
