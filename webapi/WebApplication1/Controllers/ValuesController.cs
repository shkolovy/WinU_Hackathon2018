using System.Diagnostics;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        public string Get(string id)
        {
            MetroManager.MetroLauncher.LaunchApp("Microsoft.MSPaint_5.1806.20057.0_x64__8wekyb3d8bbwe");


			//RunProcess(@"C:\Users\arshkolo\AppData\Roaming\Spotify\Spotify.exe");
            return "OK";
        }

	    private void RunProcess(string path)
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
}
