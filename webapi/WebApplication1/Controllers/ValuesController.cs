using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        public string Get(string id)
        {
            switch (id)
            {
                case "video":
                    Video();
                    break;
                case "meething":
                    break;
                case "drawing":
                    Drawing();
                    break;
                case "photo":
                    break;
            }

            GetGrapth("calendar");

            //RunWin32Process(@"C:\Users\arshkolo\AppData\Roaming\Spotify\Spotify.exe");
            return "OK";
        }

        private void Drawing()
        {
            RunUStoreApp("AdobeSystemsIncorporated.AdobePhotoshopExpress_2.4.206.0_x64__ynb6jyjzte8ga");
        }

        private void Video()
        {

        }

        private void Meeting()
        {

        }

        private void GetGrapth(string type)
        {
            switch (type)
            {
                case "calendar":
                    var client = new HttpClient();

                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJub25jZSI6IkFRQUJBQUFBQUFEWHpaM2lmci1HUmJEVDQ1ek5TRUZFN2t0ZlF4WU1ZS2VXdXl1UzRUVjlEaHpiQmtYMlNGSFFfOWhKZnhzWm9BTDc5UzY5cUZUMDBxbzgzdWpWbmZVczFtVUNET1QtX2hoSE44R0J5M2wwTlNBQSIsImFsZyI6IlJTMjU2IiwieDV0IjoiVGlvR3l3d2xodmRGYlhaODEzV3BQYXk5QWxVIiwia2lkIjoiVGlvR3l3d2xodmRGYlhaODEzV3BQYXk5QWxVIn0.eyJhdWQiOiJodHRwczovL2dyYXBoLm1pY3Jvc29mdC5jb20iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwiaWF0IjoxNTMyMzY2Nzc3LCJuYmYiOjE1MzIzNjY3NzcsImV4cCI6MTUzMjM3MDY3NywiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFVUUF1LzhJQUFBQWZhTEZYcGtCYWhROVV4cG0yMnNlM05iYW55d3JjNVJ5a0svTDdteUR5cDArNU5NSSs2T093N2VQdWRoZlNJRW9mazZaaGg5UFZxQURucFVzMTBkL3pnPT0iLCJhbXIiOlsicnNhIiwibWZhIl0sImFwcF9kaXNwbGF5bmFtZSI6IkdyYXBoIGV4cGxvcmVyIiwiYXBwaWQiOiJkZThiYzhiNS1kOWY5LTQ4YjEtYThhZC1iNzQ4ZGE3MjUwNjQiLCJhcHBpZGFjciI6IjAiLCJkZXZpY2VpZCI6IjdhMTdhYzkyLTRhOTQtNGFlOC05MDkzLTdhOWYyZWZmZGQ2MyIsImZhbWlseV9uYW1lIjoiU2hrb2xvdnkiLCJnaXZlbl9uYW1lIjoiQXJ0ZW0iLCJpcGFkZHIiOiI5NC4yNDUuODcuMzYiLCJuYW1lIjoiQXJ0ZW0gU2hrb2xvdnkiLCJvaWQiOiIxMGEyMDIwZi1jZjZjLTRhOTYtOTRiOS02OTRhZmNmNWIxYTMiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtMTcyMTI1NDc2My00NjI2OTU4MDYtMTUzODg4MjI4MS00MDI5MDk5IiwicGxhdGYiOiIzIiwicHVpZCI6IjEwMDMzRkZGQThFQkU2NEUiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZFdyaXRlIENvbnRhY3RzLlJlYWRXcml0ZSBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkV3JpdGUuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWQuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWRXcml0ZS5BbGwgRGV2aWNlTWFuYWdlbWVudE1hbmFnZWREZXZpY2VzLlByaXZpbGVnZWRPcGVyYXRpb25zLkFsbCBEZXZpY2VNYW5hZ2VtZW50TWFuYWdlZERldmljZXMuUmVhZC5BbGwgRGV2aWNlTWFuYWdlbWVudE1hbmFnZWREZXZpY2VzLlJlYWRXcml0ZS5BbGwgRGV2aWNlTWFuYWdlbWVudFJCQUMuUmVhZC5BbGwgRGV2aWNlTWFuYWdlbWVudFJCQUMuUmVhZFdyaXRlLkFsbCBEZXZpY2VNYW5hZ2VtZW50U2VydmljZUNvbmZpZy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50U2VydmljZUNvbmZpZy5SZWFkV3JpdGUuQWxsIERpcmVjdG9yeS5BY2Nlc3NBc1VzZXIuQWxsIERpcmVjdG9yeS5SZWFkV3JpdGUuQWxsIEZpbGVzLlJlYWRXcml0ZS5BbGwgR3JvdXAuUmVhZFdyaXRlLkFsbCBJZGVudGl0eVJpc2tFdmVudC5SZWFkLkFsbCBNYWlsLlJlYWRXcml0ZSBNYWlsYm94U2V0dGluZ3MuUmVhZFdyaXRlIE5vdGVzLlJlYWRXcml0ZS5BbGwgb3BlbmlkIFBlb3BsZS5SZWFkIHByb2ZpbGUgUmVwb3J0cy5SZWFkLkFsbCBTaXRlcy5SZWFkV3JpdGUuQWxsIFRhc2tzLlJlYWRXcml0ZSBVc2VyLlJlYWRCYXNpYy5BbGwgVXNlci5SZWFkV3JpdGUgVXNlci5SZWFkV3JpdGUuQWxsIGVtYWlsIiwic2lnbmluX3N0YXRlIjpbImR2Y19tbmdkIiwiZHZjX2NtcCIsImR2Y19kbWpkIiwia21zaSJdLCJzdWIiOiIxWmtmQUxnZm82aS05RGZNbG9DTWhiUEpkbkNhQm5tZ3FtTHZWTGdUNUtZIiwidGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3IiwidW5pcXVlX25hbWUiOiJhcnNoa29sb0BtaWNyb3NvZnQuY29tIiwidXBuIjoiYXJzaGtvbG9AbWljcm9zb2Z0LmNvbSIsInV0aSI6ImdTNzZ5VE0xRkVLaC1qMGduQllBQUEiLCJ2ZXIiOiIxLjAiLCJ4bXNfc3QiOnsic3ViIjoiUzNCZ0czdUhGSVpOcFotcV9Gb1E1Y0QySWktS1FZbjRoLXFKQUF1bXBSUSJ9fQ.B5N7YD02JirdQSZfuWhWGhH85hnm-1mh6x_D8u7JrfDoUq2eNNwR-_Tt64eYyoZ_EO5d_Q2tDSgk7nubK0gb6N-AafcdbEVkytd4UCAu_gBSB1XA4IlYVddhUy1dQvPVce3EHBS4T-v1GWcZe3mm7i1zp15W-PVqIFXVoGRLam8X1jzC0VBij6jDj1fghfbwmxnpjScvMWg-UUX1XduDd1ez4_V5UrSlx_0M_wdbjb-YHc-QCb-n4CXsmHDMfXvtuDQUqqKk450nvcUKAO9ZBqyYptNESlCQ0io9p_547g1BP7jxUFjSh0pEpzlnJWICRM863AyOrc-Gi_5xnMnQdg");


                    // List data response.
                    var response = client.GetAsync("https://graph.microsoft.com/v1.0/me/calendarview?startdatetime=2018-07-30T14:55:10.310Z&enddatetime=2018-07-30T16:27:10.310Z").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                    if (response.IsSuccessStatusCode)
                    {
                        var contents = response.Content.ReadAsStringAsync().Result;

                        dynamic jsonResponse = JsonConvert.DeserializeObject(contents);
                        var a = jsonResponse.value[0].body;
                        //var account = JsonConvert.DeserializeObject<GrapthApiType>(contents);


                        //                    var dataObjects = response.Content.ReadAsAsync<object>().Result;
                        //var dataObjects1 = response.Content.ReadAsAsync<GrapthApiType>().Result;
                    }
                    else
                    {
                        
                    }
                    break;
            }
        }

        private void RunUStoreApp(string name)
        {
            MetroManager.MetroLauncher.LaunchApp(name);
        }

        private void RunWin32Process(string path)
	    {
		    var p = new Process
		    {
			    StartInfo =
			    {
				    FileName = path,
				    CreateNoWindow = true
			    }
		    };
		    p.Start();
        }
    }

    [Serializable]
    public class GrapthApiType
    {
        public IList<BodyApiType> value { get; set; }
    }

    [Serializable]
    public class BodyApiType
    {
        public string body { get; set; }
    }
}
