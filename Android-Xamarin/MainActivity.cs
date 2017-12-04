using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Microsoft.AppCenter.Push;
using Firebase;
using System.Text;

namespace Android_Xamarin
{
    [Activity(Label = "Android_Xamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;
       
        protected override void OnCreate(Bundle bundle)
        {
            FirebaseApp.InitializeApp(ApplicationContext);
            AppCenter.LogLevel = LogLevel.Verbose;
            //Push.Enabled = true;
            //AppCenter.SetLogUrl("https://in-staging-south-centralus.staging.avalanch.es");
            AppCenter.Start("f6788885-ef9a-4390-badb-037164833c4d",
                   typeof(Analytics), typeof(Crashes), typeof(Distribute), typeof(Push));
            //var installid = AppCenter.InstallID;
            ////////////////////////////////////////////////////////////////////
            // This should come before AppCenter.Start() is called
            Push.PushNotificationReceived += (sender, e) => {

                // Add the notification message and title to the message
                var summary = $"Push notification received:" +
                                    $"\n\tNotification title: {e.Title}" +
                                    $"\n\tMessage: {e.Message}";

                // If there is custom data associated with the notification,
                // print the entries
                if (e.CustomData != null)
                {
                    summary += "\n\tCustom data:\n";
                    foreach (var key in e.CustomData.Keys)
                    {
                        summary += $"\t\t{key} : {e.CustomData[key]}\n";
                    }
                }

                // Send the notification summary to debug output
                System.Diagnostics.Debug.WriteLine(summary);
            };
            // 绑定 Click 事件

            Analytics.TrackEvent("Click");
            Analytics.TrackEvent("FindViewById");
            //Attachment code
            Crashes.ShouldAwaitUserConfirmation = () =>
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetTitle("Crash detected. Send anonymous crash report?")
               .SetNegativeButton("send", (s, e) =>
               {
                   Crashes.NotifyUserConfirmation(UserConfirmation.Send);
               })
                .SetPositiveButton("Always Send", (s, e) =>
                {
                    Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend);
                })
                .SetNeutralButton("Don't Send", (s, e) =>
                {
                    Crashes.NotifyUserConfirmation(UserConfirmation.DontSend);
                });
                AlertDialog alertDialog = builder.Create();
                alertDialog.Show();
                return true;
            };
            //////////////////////////////////////////////////////////////////////
            Crashes.GetErrorAttachments = (ErrorReport report) =>
            {
                // Your code goes here.
                return new ErrorAttachmentLog[]
                {
        ErrorAttachmentLog.AttachmentWithText("Hello world!", "hello.txt"),
        ErrorAttachmentLog.AttachmentWithBinary(Encoding.UTF8.GetBytes("Fake image"), "fake_image.jpeg", "image/jpeg")
                };
            };
            Crashes.SendingErrorReport += (sender, e) =>
            {
                Toast.MakeText(this, $"senting crash report", ToastLength.Short).Show();
            };
            Crashes.SentErrorReport += (sender, e) =>
            {
                AppCenterLog.Info("AppCenterXamarin--MonkeysApp", "sent error report successfully");
                Toast.MakeText(this, $"sent crash report successfully", ToastLength.Short).Show();
            };
            Crashes.FailedToSendErrorReport += (sender, e) =>
            {
                Toast.MakeText(this, $"failed to send a crash log", ToastLength.Short).Show();
            };
            //////////////////////////////////////////////////////////////////
            base.OnCreate(bundle);
            // 加载布局
            SetContentView(Resource.Layout.Main);
            // 获取布局中的控件
            Button say = FindViewById<Button>(Resource.Id.sayHello);
            TextView show = FindViewById<TextView>(Resource.Id.showHello);
            say.Click += (sender, e) =>
            {
                Analytics.TrackEvent("Crashes");
                count++;
                show.Text = "Hello, Android";
                say.Text = $"You Clicked {count}";

                if (count > 5)
                {
                    //Crashes.Enabled = true;
                    //throw new System.Exception("error:click>5");
                    Crashes.GenerateTestCrash();
                }

                // Toast 通知
                Toast.MakeText(this, $"You Clicked {count}", ToastLength.Short).Show();
            };

        }
    }
}
