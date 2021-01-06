using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace ConsoleWebClient.old
{   
    class IngredientsList
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
        
        
    }
    
    class Data
    {
        public List<Ingredient> Ingredients { get; set; }
    }

    class Ingredient
    {
        public string Id { get; set; }
        public List<Details> Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
     class Details
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string QuantityType { get; set; }
        public string KeptAt { get; set; }
        public DateTime UseByDate { get; set; }
    }
}
