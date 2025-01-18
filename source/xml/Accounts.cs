using System.Text;
using System.Net.Http.Headers;

namespace mofh.xml
{
    public static class Accounts
    {
        /// <summary>
        /// Create a new account (https://api.myownfreehost.net/XML/accounts/create)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="username">User username.</param>
        /// <param name="password">User password</param>
        /// <param name="email">User username</param>
        /// <param name="domain">User domain</param>
        /// <param name="plan">User plan</param>
        public static async void Create(string apiUsername, string apiPassword, string username, string password, string email, string domain, string plan)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/createacct.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("username=" + username + "&password=" + password + "&contactemail=" + email + "&domain=" + domain + "&plan=" + plan);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Suspend an account (https://api.myownfreehost.net/XML/accounts/suspend)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="username">User username.</param>
        /// <param name="reason">Suspend reason.</param>
        public static async void Suspend(string apiUsername, string apiPassword, string username, string reason)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/suspendacct.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("user=" + username + "&reason=" + reason);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Unsuspend an account (https://api.myownfreehost.net/XML/accounts/unsuspend)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="username">User username.</param>
        public static async void Unsuspend(string apiUsername, string apiPassword, string username)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/unsuspendacct.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("user=" + username);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Remove an account (https://api.myownfreehost.net/XML/accounts/remove)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="username">User username.</param>
        public static async void Remove(string apiUsername, string apiPassword, string username)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/removeacct.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("user=" + username);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Change an account password (https://api.myownfreehost.net/XML/accounts/change-password)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="username">User username.</param>
        /// <param name="password">New password.</param>
        public static async void ChangePassword(string apiUsername, string apiPassword, string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/passwd.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("user=" + username + "&pass=" + password);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Change an account package (https://api.myownfreehost.net/XML/accounts/change-package)
        /// </summary>
        /// <param name="apiUsername"></param>
        /// <param name="apiPassword"></param>
        /// <param name="username"></param>
        /// <param name="plan"></param>
        public static async void ChangePackage(string apiUsername, string apiPassword, string username, string plan)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/changepackage.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("user=" + username + "&pkg=" + plan);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}