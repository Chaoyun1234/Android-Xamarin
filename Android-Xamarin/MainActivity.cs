using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Distribute;
using Microsoft.Azure.Mobile.Push;
using Firebase;

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
            MobileCenter.Start("7462b81e-72c5-4272-bf9c-2a62c4a16f84",
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
