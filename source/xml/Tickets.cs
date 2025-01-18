using System.Text;
using System.Net.Http.Headers;

namespace mofh.xml
{
    public static class Tickets
    {
        /// <summary>
        /// Create a new ticket (https://api.myownfreehost.net/XML/tickets/create)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="domain">Domain associated with the ticket.</param>
        public static async void Create(string apiUsername, string apiPassword, string domain)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/supportnewticket.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("username:password"));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("api_user=" + apiUsername + "&api_key=" + apiPassword + "&domain_name=" + domain);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        /// <summary>
        /// Create a new reply from user (https://api.myownfreehost.net/XML/tickets/user-reply)
        /// </summary>
        /// <param name="apiUsername">API username.</param>
        /// <param name="apiPassword">API password.</param>
        /// <param name="ticketId">Ticket ID.</param>
        /// <param name="domain">Domain associated with the ticket.</param>
        public static async void UserReply(string apiUsername, string apiPassword, string ticketId, string domain)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://panel.myownfreehost.net/xml-api/supportreplyticket.php"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("api_user=" + apiUsername + "&api_key=" + apiPassword + "&domain_name=" + domain + "&ticket_id=" + ticketId);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}