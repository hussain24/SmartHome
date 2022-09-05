using SmartHome.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHome.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(OnButtonClicked);//new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
        private async void OnButtonClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }
    }
}