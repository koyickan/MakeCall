using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MakeCall
{
    [Activity(Label = "MakeCall", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button BtnCall = FindViewById<Button>(Resource.Id.button1);
            BtnCall.Click += BtnCall_Click;

            Button BtnSms = FindViewById<Button>(Resource.Id.button2);
            BtnSms.Click += BtnSms_Click;

            Button BtnEmail = FindViewById<Button>(Resource.Id.button3);
            BtnEmail.Click += BtnEmail_Click; 
                           
        }

        private void BtnEmail_Click(object sender, System.EventArgs e)
        {
            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra(Android.Content.Intent.ExtraEmail,
                           new string[] { "jominworld@gmail.com.com", "c0684667@mylambton.ca" });

            email.PutExtra(Android.Content.Intent.ExtraCc, new string[] { "c0684667@mylambton.ca" });

            email.PutExtra(Android.Content.Intent.ExtraSubject, "Test Email");

            email.PutExtra(Android.Content.Intent.ExtraText, "This is a test email from XAMARIN Android CSD3184");

            email.SetType("message/rfc822");
            StartActivity(email);

            Toast.MakeText(this, "Worked", ToastLength.Long).Show();
        }

        private void BtnSms_Click(object sender, System.EventArgs e)
        {
            var smsContent = FindViewById<EditText>(Resource.Id.editText1).Text;
            var smsUri = Android.Net.Uri.Parse("smsto:+13657774101");
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            smsIntent.PutExtra("sms_body", smsContent);
            StartActivity(smsIntent);

            Toast.MakeText(this, "Hello", ToastLength.Long).Show();
        }

        private void BtnCall_Click(object sender, System.EventArgs e)
        {

            var uri1 = Android.Net.Uri.Parse("tel:9495800417");
            var intent1 = new Intent(Intent.ActionCall,uri1);
            StartActivity(intent1);

            Toast.MakeText(this, "Worked",ToastLength.Long).Show();
        }
    }
}

