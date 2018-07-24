using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Media.SpeechRecognition;
using Windows.System;
using Windows.UI.Notifications;

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
                // In a real app, these would be initialized with actual data
                string title = "Are you happy with Windows U?";
                string content = "Did that action helped you?";
                string logo = "ms-appdata:///local/Andrew.jpg";

                // Construct the visuals of the toast
                ToastVisual visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = title
                            },

                            new AdaptiveText()
                            {
                                Text = content
                            },
                        },

                        AppLogoOverride = new ToastGenericAppLogo()
                        {
                            Source = logo,
                            HintCrop = ToastGenericAppLogoCrop.Circle
                        }
                    }
                };

                ToastContent toastContent = new ToastContent()
                {
                    Actions = new ToastActionsCustom()
                    {
                        Buttons =
                        {
                            new ToastButton("😃", "action=viewdetails&contentId=351")
                            {
                                ActivationType = ToastActivationType.Foreground
                            },

                            new ToastButton("🙁", "action=remindlater&contentId=351")
                            {
                                ActivationType = ToastActivationType.Background
                            }
                        }
                    },
                    Visual = visual,
                    Duration = ToastDuration.Short
                    
                };
                var toast = new ToastNotification(toastContent.GetXml());
                toast.Tag = "18365";
                toast.Group = "wallPosts";
                ToastNotificationManager.CreateToastNotifier().Show(toast);

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
                },
                {
                "WriteBirthdayCardCommand", (Action)(async () =>
                    {
                         CallApi("powerpointBirthday");
                         action();
                    })
                },
                {
                "WriteCVCommand", (Action)(async () =>
                    {
                         CallApi("wordResume");
                         action();
                    })
                },
                {
                "WriteResumeCommand", (Action)(async () =>
                    {
                         CallApi("wordResume");
                         action();
                    })
                },
                {
                "WriteLetterCommand", (Action)(async () =>
                    {
                         CallApi("wordLetter");
                         action();
                    })
                },
                {
                "WriteLetterToCommand", (Action)(async () =>
                    {
                         CallApi("wordLetter");
                         action();
                    })
                },
                {
                "WatchAVideoCommand", (Action)(async () =>
                    {
                         CallApi("youtube;" + result.Text.Trim().Replace("watch",""));
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
