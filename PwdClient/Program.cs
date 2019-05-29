using System;
using System.Net.Http;
using IdentityModel.Client;

namespace PwdClient
{
    class Program
    {
        static void Main(string[] args)
        {
           var diso = DiscoveryClient.GetAsync("http://localhost:5000").Result;
            if (diso.IsError)
            {
                System.Console.WriteLine(diso.Error);
            }
            var tokenClient = new TokenClient(diso.TokenEndpoint, "pwdClient", "secret");
            //var tokenResponse = tokenClient.RequestClientCredentialsAsync("api").Result;
            var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync("bobo","123456").Result;
            if (tokenResponse.IsError)
            {
                System.Console.WriteLine(tokenResponse.Error);
            }
            else
            {
                System.Console.WriteLine(tokenResponse.Json);
            }

            var httpClient = new HttpClient();
            System.Console.WriteLine(tokenResponse.AccessToken);
            httpClient.SetBearerToken(tokenResponse.AccessToken);
            var response = httpClient.GetAsync("http://localhost:5001/api/values").Result;
            if (response.IsSuccessStatusCode)
            {
                System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
