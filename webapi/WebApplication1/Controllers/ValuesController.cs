using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Web.Http;

using System.IO;
using DocumentFormat.OpenXml.Packaging;
using System.Net;
using System.Linq;

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
                default:
                    if (id.StartsWith("youtube"))
                    {
                        YoutubeVideo(id);
                    }
                    else if (id.StartsWith("wordLetter;"))
                    {
                        DocumentContact(wordLetter, id.Replace("wordLetter;", "").Trim());
                    }
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

        private void YoutubeVideo(string id)
        {
            if (id.StartsWith("youtube;"))
            {
               Process.Start("https://www.youtube.com/results?search_query=" + id.Replace("youtube;", "").Trim().Replace(" ", "+"));
            }
        }

        private void Meeting()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebConfigurationManager.AppSettings["graphApiTocken"]);

            var response = client.GetAsync("https://graph.microsoft.com/v1.0/me/calendarview?startdatetime=2018-07-30T14:55:10.310Z&enddatetime=2018-07-30T16:27:10.310Z").Result;
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

        struct SimpleContact
        {
            public string GivenName;
            public string DisplayName;
            public string Street;
            public string City;
            public string State;
            public string PostalCode;
        };

        private void DocumentContact(string file, string param)
        {
            WebClient myWebClient = new WebClient();
            string tempfile = Path.GetTempFileName();
            myWebClient.DownloadFile(file, tempfile);

            SimpleContact? contact = GetContactDetails(param);

            if (contact.HasValue)
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(tempfile, true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    {
                        Regex regexText = new Regex("\\[Recipient\\]");
                        docText = regexText.Replace(docText, contact?.GivenName);
                    }

                    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                    
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.HeaderParts.FirstOrDefault().GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    {
                        Regex regexText = new Regex("\\[Street .*>\\]");
                        docText = regexText.Replace(docText, contact?.DisplayName + "<w:br/>" + contact?.Street + ", " + contact?.City + ", " + contact?.State + ", " + contact?.PostalCode);
                    }

                    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.HeaderParts.FirstOrDefault().GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }

                }
            }

            File.SetAttributes(tempfile, FileAttributes.Hidden);
            FileInfo fInfo = new FileInfo(tempfile);

            // Set the IsReadOnly property.
            fInfo.IsReadOnly = true;

            RunWin32Process(@"C:\Program Files (x86)\Microsoft Office\root\Office16\winword.exe", tempfile);
        }

        private SimpleContact? GetContactDetails(string text)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebConfigurationManager.AppSettings["graphApiTocken"]);
            string request = "https://graph.microsoft.com/v1.0/me/contacts";
            var response = client.GetAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var contents = response.Content.ReadAsStringAsync().Result;

                    dynamic jsonResponse = JsonConvert.DeserializeObject(contents);
                    SimpleContact contact = new SimpleContact
                    {
                        GivenName = jsonResponse.value[0].givenName.ToString(),
                        DisplayName = jsonResponse.value[0].displayName.ToString(),
                        Street = jsonResponse.value[0].homeAddress.street.ToString(),
                        City = jsonResponse.value[0].homeAddress.city.ToString(),
                        State = jsonResponse.value[0].homeAddress.state.ToString(),
                        PostalCode = jsonResponse.value[0].homeAddress.postalCode.ToString()
                    };

                    return contact;

                }
                catch
                {
                    // no meetings
                }
            }
            return null;
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
