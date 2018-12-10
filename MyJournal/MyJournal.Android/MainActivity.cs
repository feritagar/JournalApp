using Android.App;
using Android.Content.PM;
using Android.OS;
using System.IO;

namespace MyJournal.Droid
{
    [Activity(Label = "MyJournal", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            //for database
            string fileName = "journal_db.sqlite";
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(fileLocation, fileName);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //LoadApplication(new App());

            /* to be able to read from database,
            use new constructor with string parameter and pass full_path to it.*/
            LoadApplication(new App(full_path)); 
        }
    }
}