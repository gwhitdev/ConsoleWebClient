using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleWebClient
{
    class Repo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
