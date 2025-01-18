using System.Net.Http.Headers;
using System.Text;

namespace mofh
{
    public class Information
    {
        public static void APIVersion(string apiUsername, string apiPassword)
        {
            using (var client = new HttpClient())
            {
                var authToken = Encoding.ASCII.GetBytes($"{apiUsername}:{apiPassword}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var response = client.GetAsync("https://panel.myownfreehost.net/json-api/version.php").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseData);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
        }
        
    }
}