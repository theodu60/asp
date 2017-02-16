using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class StoryService
    {
        HttpClient _client = new HttpClient();

        public Story Get(int id)
        {
            var response = _client.GetAsync("http://localhost:49821/api/story/" + id).Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Story>(response.Content.ReadAsStringAsync().Result);
            return null;
        }

        public Story Get()
        {
            var response = _client.GetAsync("http://localhost:49821/api/story/").Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Story>(response.Content.ReadAsStringAsync().Result);
            return null;
        }
    }
}
