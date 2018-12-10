﻿
using SQLite;
using System;
using Xamarin.Forms;

namespace MyJournal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        //it will executed everytime when we go to main page. We will be able to from database
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Journal>();

                var books = conn.Table<Journal>().OrderByDescending(x => x.PostDate).ToList();
                booksListView.ItemsSource = books;
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewJournal());
        }
        //delete selected item from list
        public void Delete(Object Sender, EventArgs args)
        {
            var book = booksListView.SelectedItem;
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.Delete(book);
            }
            Navigation.PushAsync(new MainPage());
        }

        public void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem != null)
            {
                Navigation.PushAsync(new JournalDetail
                {
                    BindingContext = e.SelectedItem as Journal
                });
            }
        }
    }
}

