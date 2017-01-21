using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class UsersService
    {
        HttpClient _client = new HttpClient();
        public Users Get(int id)
        {
            var response = _client.GetAsync("http://localhost:49821/api/values/" + id).Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Users>(response.Content.ReadAsStringAsync().Result);
            return null;
        }
    }
}
