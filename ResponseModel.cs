using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleWebClient
{


    public class Rootobject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
        public object instance { get; set; }
    }

    public class Data
    {
        public List<Ingredient> ingredients { get; set; }
    }

    public class Ingredient
    {
        public string id { get; set; }
        public Details details { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
    }

    public class Details
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public string quantityType { get; set; }
        public string keptAt { get; set; }
        public DateTime useByDate { get; set; }
    }


}
