using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using translater_2.Views;
using Xamarin.Forms;

namespace translater_2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new TranslatePage());
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
    }
}
