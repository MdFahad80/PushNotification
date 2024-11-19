using Android.App;
using Firebase.Messaging;

namespace PushNotification.Platforms.Android.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public FirebaseService() { }

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
            if (Preferences.ContainsKey("DeviceToken")) {
                Preferences.Remove("DeviceToken");    
            }
            Preferences.Set("DeviceToken", token);
        }

    }
}
