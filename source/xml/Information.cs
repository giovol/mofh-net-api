using System.Text;

namespace mofh.xml
{
    public static class Information
    {
        /// <summary>
        /// Get the API version (https://api.myownfreehost.net/XML/information/api-version)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        public static async void APIVersion(string apiUsername, string apiPassword)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://panel.myownfreehost.net/xml-api/version.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// List all packages (https://api.myownfreehost.net/XML/information/list-packages)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        public static async void ListPackages(string apiUsername, string apiPassword)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://panel.myownfreehost.net/xml-api/listpkgs.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}