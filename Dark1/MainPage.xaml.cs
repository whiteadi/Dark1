using Dark1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dark1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string myJokeProperty;
        public string MyJokeProperty
        {
            get { return myJokeProperty; }
            set
            {
                myJokeProperty = value;
                OnPropertyChanged(nameof(MyJokeProperty)); // Notify that there was a change on this property
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            fetchNewJoke();
        }

        void Button_Clicked(object sender, System.EventArgs e)
        {
            fetchNewJoke();
        }

        private async void fetchNewJoke()
        {
            var joke = await App.JokeManager.GetTasksAsync();

            MyJokeProperty = joke.Joke;
        }

        public void RightSwipe(object sender, EventArgs e)
        {
            fetchNewJoke();
        }

        public void LeftSwipe(object sender, EventArgs e)
        {
            fetchNewJoke();
        }
    }
}
