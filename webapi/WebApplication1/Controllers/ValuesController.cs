using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        private const string wordResume = "https://omextemplates.content.office.net/support/templates/en-us/tf16412149.docx";
        private const string wordLetter = "https://omextemplates.content.office.net/support/templates/en-us/tf00002014.docx";
        private const string powerpointBirthday = "https://omextemplates.content.office.net/support/templates/en-us/tf00001088.pptx";

        public string Get(string id)
        {
            switch (id)
            {
                case "video":
                    Video();
                    break;
                case "meeting":
                    Meeting();
                    break;
                case "drawing":
                    Drawing();
                    break;
                case "photo":
                    Photo();
                    break;
                case "wordResume":
                    Document(wordResume);
                    break;
                case "wordLetter":
                    Document(wordLetter);
                    break;
                case "powerpointBirthday":
                    Card(powerpointBirthday);
                    break;
            }

            return "OK";
        }

        private void Drawing()
        {
            RunUStoreApp("Microsoft.MSPaint_5.1806.20057.0_x64__8wekyb3d8bbwe");
        }

        private void Photo()
        {
            RunUStoreApp("AdobeSystemsIncorporated.AdobePhotoshopExpress_2.4.206.0_x64__ynb6jyjzte8ga");
        }

        private void Video()
        {

        }

        private void Meeting()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJub25jZSI6IkFRQUJBQUFBQUFEWHpaM2lmci1HUmJEVDQ1ek5TRUZFYzJRT3d0V2JrU055QlhwTV9mWU9oa0VkaTF0V3ItZ2dwM2Y4dXItbHZDNmJock9DSW45SlVUeWg5X21vczYyLUN6YS1Db3JkX2RDNGhLSWhMNXdVUlNBQSIsImFsZyI6IlJTMjU2IiwieDV0IjoiN19adWYxdHZrd0x4WWFIUzNxNmxValVZSUd3Iiwia2lkIjoiN19adWYxdHZrd0x4WWFIUzNxNmxValVZSUd3In0.eyJhdWQiOiJodHRwczovL2dyYXBoLm1pY3Jvc29mdC5jb20iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwiaWF0IjoxNTMyNDI3NDk2LCJuYmYiOjE1MzI0Mjc0OTYsImV4cCI6MTUzMjQzMTM5NiwiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFVUUF1LzhJQUFBQXpWVVk0UEJROUdxMHBlb1dBWVI4ZVI5TGx5S2UyVDh5TENpV0psc2tTVDJXWU54Q1BRd05ubEMyVzRhekpZOGROREtheWJKYk5vY1ZRNVJHS1BWcmp3PT0iLCJhbXIiOlsicnNhIiwibWZhIl0sImFwcF9kaXNwbGF5bmFtZSI6IkdyYXBoIGV4cGxvcmVyIiwiYXBwaWQiOiJkZThiYzhiNS1kOWY5LTQ4YjEtYThhZC1iNzQ4ZGE3MjUwNjQiLCJhcHBpZGFjciI6IjAiLCJkZXZpY2VpZCI6IjdhMTdhYzkyLTRhOTQtNGFlOC05MDkzLTdhOWYyZWZmZGQ2MyIsImZhbWlseV9uYW1lIjoiU2hrb2xvdnkiLCJnaXZlbl9uYW1lIjoiQXJ0ZW0iLCJpcGFkZHIiOiI5NC4yNDUuODcuMzYiLCJuYW1lIjoiQXJ0ZW0gU2hrb2xvdnkiLCJvaWQiOiIxMGEyMDIwZi1jZjZjLTRhOTYtOTRiOS02OTRhZmNmNWIxYTMiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtMTcyMTI1NDc2My00NjI2OTU4MDYtMTUzODg4MjI4MS00MDI5MDk5IiwicGxhdGYiOiIzIiwicHVpZCI6IjEwMDMzRkZGQThFQkU2NEUiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZFdyaXRlIENvbnRhY3RzLlJlYWRXcml0ZSBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkV3JpdGUuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWQuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWRXcml0ZS5BbGwgRGV2aWNlTWFuYWdlbWVudE1hbmFnZWREZXZpY2VzLlByaXZpbGVnZWRPcGVyYXRpb25zLkFsbCBEZXZpY2VNYW5hZ2VtZW50TWFuYWdlZERldmljZXMuUmVhZC5BbGwgRGV2aWNlTWFuYWdlbWVudE1hbmFnZWREZXZpY2VzLlJlYWRXcml0ZS5BbGwgRGV2aWNlTWFuYWdlbWVudFJCQUMuUmVhZC5BbGwgRGV2aWNlTWFuYWdlbWVudFJCQUMuUmVhZFdyaXRlLkFsbCBEZXZpY2VNYW5hZ2VtZW50U2VydmljZUNvbmZpZy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50U2VydmljZUNvbmZpZy5SZWFkV3JpdGUuQWxsIERpcmVjdG9yeS5BY2Nlc3NBc1VzZXIuQWxsIERpcmVjdG9yeS5SZWFkV3JpdGUuQWxsIEZpbGVzLlJlYWRXcml0ZS5BbGwgR3JvdXAuUmVhZFdyaXRlLkFsbCBJZGVudGl0eVJpc2tFdmVudC5SZWFkLkFsbCBNYWlsLlJlYWRXcml0ZSBNYWlsYm94U2V0dGluZ3MuUmVhZFdyaXRlIE5vdGVzLlJlYWRXcml0ZS5BbGwgb3BlbmlkIFBlb3BsZS5SZWFkIHByb2ZpbGUgUmVwb3J0cy5SZWFkLkFsbCBTaXRlcy5SZWFkV3JpdGUuQWxsIFRhc2tzLlJlYWRXcml0ZSBVc2VyLlJlYWRCYXNpYy5BbGwgVXNlci5SZWFkV3JpdGUgVXNlci5SZWFkV3JpdGUuQWxsIGVtYWlsIiwic2lnbmluX3N0YXRlIjpbImR2Y19tbmdkIiwiZHZjX2NtcCIsImR2Y19kbWpkIiwia21zaSJdLCJzdWIiOiIxWmtmQUxnZm82aS05RGZNbG9DTWhiUEpkbkNhQm5tZ3FtTHZWTGdUNUtZIiwidGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3IiwidW5pcXVlX25hbWUiOiJhcnNoa29sb0BtaWNyb3NvZnQuY29tIiwidXBuIjoiYXJzaGtvbG9AbWljcm9zb2Z0LmNvbSIsInV0aSI6ImJNVDBvTkdZamtLWFpNZ19PNFVGQUEiLCJ2ZXIiOiIxLjAiLCJ4bXNfc3QiOnsic3ViIjoiUzNCZ0czdUhGSVpOcFotcV9Gb1E1Y0QySWktS1FZbjRoLXFKQUF1bXBSUSJ9fQ.kOsjrYfoQg0uZMKyHCAh-GcMwMpVvgnMnUbshc2bl6kAi5K4BrktYrp6eJxw1AavRSL1B0TIr5N34sqpvdpGjkpD8jPMXYG_2luzMGb3Ug5nBhrLA4GwJAZZS5Y3RmJIGlSSfP7I6TvaZrWOP1PEdL3SjHqHGPzBta8_QsorvcDteBHISVN9DybVsBmvoc-vAEH2hz43l8nRwEM0T_db2eXpdbQn3-W2Q99tAqEEEO5vj2EhPxbcWPsIn65-aryy8Z0NToFLQGSHxyC-1YvGusBUpQfaZBZLFaruZ5LbziWwhl632gDdIBvUyhl_SR1MCSqNvj_FyUPpguAPRtTYmw");

            var response = client.GetAsync("https://graph.microsoft.com/v1.0/me/calendarview?startdatetime=2018-07-30T14:55:10.310Z&enddatetime=2018-07-30T16:27:10.310Z").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var contents = response.Content.ReadAsStringAsync().Result;

                    dynamic jsonResponse = JsonConvert.DeserializeObject(contents);
                    string body = jsonResponse.value[0].body.ToString();

                    var pat = @"(?:(?:https?):\/\/teams\.)(?:\([-A-Z0-9+&@#\/%=~_|$?!:,.]*\)|[-A-Z0-9+&@#\/%=~_|$?!:,.])*(?:\([-A-Z0-9+&@#\/%=~_|$?!:,.]*\)|[A-Z0-9+&@#\/%=~_|$])";
                    var r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(body);
                    var teamsLink = m.Groups[0].ToString();
                    Process.Start(teamsLink);
                }
                catch
                {
                    // no meetings
                }
            }
            else
            {
            }
        }

        private void Document(string file)
        {
            RunWin32Process(@"C:\Program Files (x86)\Microsoft Office\root\Office16\winword.exe", file);
        }

        private void Card(string file)
        {
            RunWin32Process(@"C:\Program Files (x86)\Microsoft Office\root\Office16\powerpnt.exe", file);
        }

        private void RunUStoreApp(string name)
        {
            MetroManager.MetroLauncher.LaunchApp(name);
        }

        private void RunWin32Process(string path, string arg = "")
        {
            var p = new Process
            {
                StartInfo =
                {
                    FileName = path,
                    CreateNoWindow = true,
                    Arguments = arg
                }
            };
            p.Start();
        }
    }
}
