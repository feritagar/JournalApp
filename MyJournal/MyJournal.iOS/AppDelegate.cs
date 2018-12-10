using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MyJournal.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //to be able to read from database
            string fileName = "journal_db.sqlite";
            // check this. different for android. "Library" and ".." must be exacly like this.
            string fileLocation = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library");
            string full_path = Path.Combine(fileLocation, fileName);


            global::Xamarin.Forms.Forms.Init();
            //LoadApplication(new App());
            // to be able to read from database, use new constructor with string parameter and pass full_path to it.like we did for android
            LoadApplication(new App(full_path));

            return base.FinishedLaunching(app, options);
        }
    }
}
