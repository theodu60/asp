﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Text;
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

        public bool Post(string email, string password)
        {


            var response = _client.PostAsync("http://localhost:49821/api/users/Login?email=" + email + "&password=" + password, null).Result;
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
           

        }
    }
}
