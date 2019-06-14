using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Repertoire_PERSO.Data;
using System.IO;

namespace Repertoire_PERSO
{
    public partial class App : Application
    {
        static Database database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Contact.db3"));
                }
                return database;
            }
        }

        
    }
}
