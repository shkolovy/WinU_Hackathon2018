using System;
using System.Collections.Generic;
using System.Net.Http;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Media.SpeechRecognition;
using Windows.System;

namespace WinU_Hackathon2018
{
    class CortanaFunctions
    {
        public static async void RegisterVCD()
        {
            var vcd = await Package.Current.InstalledLocation.GetFileAsync(@"CustomCortanaCommands.xml");

            await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(vcd);
        }

        private static void CallApi(string id)
        {
            var client = new HttpClient();

            var response = client.GetAsync($"http://localhost:56898/api/values/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                //good !
            }
        }

        public static void RunCommand(VoiceCommandActivatedEventArgs cmd, Action action)
        {
            SpeechRecognitionResult result = cmd.Result;
            string commandName = result.RulePath[0];

            var vcdLookup = new Dictionary<string, Delegate>{
                {
                    "WatchVideoCommand", (Action)(async () =>
                    {
                        CallApi("video");
                        action();
                    })
                },
                {
                "DrawingCommand", (Action)(async () =>
                    {
                         CallApi("drawing");
                         action();
                    })
                },
                {
                "PhotoEditCommand", (Action)(async () =>
                    {
                         CallApi("photo");
                         action();
                    })
                },
                {
                "GoToMeetingCommand", (Action)(async () =>
                    {
                         CallApi("meeting");
                         action();
                    })
                }
            };

            Delegate command;

            if (vcdLookup.TryGetValue(commandName, out command))
            {
                command.DynamicInvoke();
            }
        }
    }
}
