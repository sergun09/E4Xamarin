using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Zoo_E4
{
    public partial class App : Application
    {
        public static string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "zooE4.db");

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Zoo_E4.Vues.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
