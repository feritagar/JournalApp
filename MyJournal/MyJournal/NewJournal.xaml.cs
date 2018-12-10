
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyJournal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewJournal : ContentPage
	{
        public NewJournal()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Journal journal = new Journal()
            {
                JournalName = titleEntry.Text,
                JournalDetail = detailEntry.Text,
                PostDate = DateTime.Now
            };

            //create connection to database. when you use "using", you dont need close connection
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                //make sure the table exist
                conn.CreateTable<Journal>();
                //number of rows in table
                var numberOfRows = conn.Insert(journal);

                if (numberOfRows > 0)
                    DisplayAlert("Success", "Journal succesfully inserted", "Great!");
                else
                    DisplayAlert("Failure", "Journal failed to be inserted", "Dang it!");
            }

            Navigation.PushAsync(new MainPage());

        }
    }
}