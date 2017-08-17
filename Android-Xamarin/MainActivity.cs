using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Distribute;
using Microsoft.Azure.Mobile.Push;
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
            MobileCenter.LogLevel = LogLevel.Verbose;
            Push.Enabled = true;
            //MobileCenter.SetLogUrl("https://in-staging-south-centralus.staging.avalanch.es");
            MobileCenter.Start("64f8216f-7296-48c2-b487-8a9341e24abb",
                   typeof(Analytics), typeof(Crashes), typeof(Distribute), typeof(Push));
            var installid = MobileCenter.InstallId;
            
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
            Crashes.ShouldProcessErrorReport = (ErrorReport report) =>
            {
                // Check the report in here and return true or false depending on the ErrorReport.
                return false;
            };
            Crashes.ShouldAwaitUserConfirmation = () =>
            {
                // Build your own UI to ask for user consent here. SDK does not provide one by default.

                // Return true if you just built a UI for user consent and are waiting for user input on that custom U.I, otherwise false.
                return false;
            };
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
                // Your code, e.g. to present a custom UI.
            };
            Crashes.SentErrorReport += (sender, e) =>
            {
                // Your code, e.g. to hide the custom UI.
            };
            Crashes.FailedToSendErrorReport += (sender, e) =>
            {
                // Your code goes here.
            };

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

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
                    Crashes.Enabled = true;
                    //throw new System.Exception("error:click>5");
                    Crashes.GenerateTestCrash();
                }

                // Toast 通知
                Toast.MakeText(this, $"You Clicked {count}", ToastLength.Short).Show();
            };

        }
    }
}
