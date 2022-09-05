using SmartHome.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHome
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TurnOnFan(object sender, EventArgs e)
        {

            var isSent= ((App)(Application.Current)).PublishMessage("TurnOnTheFan");
            //if (isSent)
            //{
            //    await DisplayAlert("Smart Home", "Your Fan Has Been Turned On.", "OK");
            //}
            //else
            //{
            //    await DisplayAlert("Smart Home", "You are not connected to Internet.", "OK");
            //}



        }

        private async void TurnOffFan(object sender, EventArgs e)
        {
            var isSent = ((App)(Application.Current)).PublishMessage("TurnOffTheFan");
            //if (isSent)
            //{
            //    await DisplayAlert("Smart Home", "Your Fan Has Been Turned Off.", "OK");
            //}
            //else
            //{
            //    await DisplayAlert("Smart Home", "You are not connected to Internet.", "OK");
            //}
        }
    }
}
