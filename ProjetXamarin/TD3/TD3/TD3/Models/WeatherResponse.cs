using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD3.Models
{
    public class WeatherResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("weather")]
        public List<WeatherObject> Weather { get; set; }
        [JsonProperty("main")]
        public MainObject Main { get; set; }
        [JsonProperty("visibility")]
        public long Visibility { get; set; }
        [JsonProperty("wind")]
        public WindObject Wind { get; set; }
        [JsonProperty("sys")]
        public SysObject Sys { get; set; }
        [JsonProperty("dt")]
        public int Dt { get; set; }
        [JsonProperty("timezone")]
        public int Timezone { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public partial class MainObject
        {
            [JsonProperty("temp")]
            public double Temp { get; set; }
            [JsonProperty("humidity")]
            public long Humidity { get; set; }
            [JsonProperty("feels_like")]
            public double Feelslike { get; set; }
        }
        public partial class WeatherObject
        {
            [JsonProperty("main")]
            public string Main { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("icon")]
            public string Icon { get; set; }
        }
        public partial class WindObject
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }
            [JsonProperty("deg")]
            public long Deg { get; set; }
        }
        public partial class SysObject
        {
            [JsonProperty("sunrise")]
            public int Sunrise { get; set; }
            [JsonProperty("sunset")]
            public int Sunset { get; set; }
        }  
    }

}
