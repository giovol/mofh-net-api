using System.Text;
using System.Net.Http.Headers;

namespace mofh.xml
{
    public static class Domains
    {
        /// <summary>
        /// Check if a domain is available (https://api.myownfreehost.net/XML/domains/check-if-available)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="domain">Domain to check.</param>
        public static async void CheckIfAvailable(string apiUsername, string apiPassword, string domain)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/checkavailable.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("api_user=" + apiUsername + "&api_key=" + apiPassword + "&domain=" + domain);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Get the user's domains (https://api.myownfreehost.net/XML/domains/get-user-domains)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="username">User to check.</param>
        public static async void GetUserDomains(string apiUsername, string apiPassword, string username)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/getuserdomains.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("api_user=" + apiUsername + "&api_key=" + apiPassword + "&username=" + username);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Get user by domain (https://api.myownfreehost.net/XML/domains/get-user-by-domain)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="domain">Domain to check.</param>
        public static async void GetUserByDomain(string apiUsername, string apiPassword, string domain)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/getdomainuser.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("api_user=" + apiUsername + "&api_key=" + apiPassword + "&domain=" + domain);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Validate domain by CNAME (https://api.myownfreehost.net/XML/domains/validate-domain-by-cname)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="domain">Domain to validate.</param>
        public static async void ValidateDomainByCNAME(string apiUsername, string apiPassword, string domain)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/getcname.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("username:password"));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("api_user=" + apiUsername + "&api_key=" + apiPassword + "&domain_name=" + domain);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}