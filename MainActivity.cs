using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase;
using Firebase.Database;

namespace inWay
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        FirebaseDatabase database;
        Button btnConexion;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnConexion =
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
      

        }

        private void BtnConexion_Click(object sender, System.EventArgs e)
        {
            InicializaDatabase();
        }

        void InicializaDatabase()
        {
            var app = FirebaseApp.InitializeApp(this);
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("inway-2021")
                    .SetApiKey("AIzaSyAcAnodCJ3rzgTX94bCPe8yN0zNPKFTVR8")
                    .SetDatabaseUrl("https://inway-2021-default-rtdb.firebaseio.com")
                    .SetStorageBucket("inway-2021.appspot.com")
                    .Build();
                app = FirebaseApp.InitializeApp(this, options);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }

            DatabaseReference dbref=database.GetReference("SoporteUsuario");
            dbref.SetValue("Ticket1");

            Toast.MakeText(this, "Exitoso", ToastLength.Short).Show();
        }

    }
}