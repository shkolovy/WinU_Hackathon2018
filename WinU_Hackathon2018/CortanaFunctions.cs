using System;
using System.Collections.Generic;
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

        public static void RunCommand(VoiceCommandActivatedEventArgs cmd)
        {
            SpeechRecognitionResult result = cmd.Result;
            string commandName = result.RulePath[0];

            var vcdLookup = new Dictionary<string, Delegate>{

                {
                    "WatchVideoCommand", (Action)(async () =>
                    {
                         Uri website = new Uri(@"http://www.office.com");
                         await Launcher.LaunchUriAsync(website);
                    })
                },
                {
                  "OpenWebsiteCommand", (Action)(async () =>
                    {
                         Uri website = new Uri(@"http://www.office.com");
                         await Launcher.LaunchUriAsync(website);
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
