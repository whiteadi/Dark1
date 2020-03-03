using Dark1.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dark1
{
    public partial class App : Application
    {
        public static JokeManager JokeManager { get; private set; }

        public App()
        {
            InitializeComponent();
            JokeManager = new JokeManager(new RestService());
            MainPage = new MainPage();
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
