using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace KURS.ViewModels
{
    class AboutViewModel : BaseViewModel
    {
        public Command SiteCommand { get; }
        public Command PhoneCommand { get; }
        public Command AdressCommand { get; }

        public AboutViewModel()
        {
            SiteCommand = new Command(SiteCommandExecuted);
            PhoneCommand = new Command(PhoneCommandExecuted);
            AdressCommand = new Command(AdressCommandExecuted);
        }

        public async void SiteCommandExecuted()
        {
            await Browser.OpenAsync("https://koshelyok.by/", BrowserLaunchMode.SystemPreferred);
        }
        public async void PhoneCommandExecuted()
        {
            try
            {
                PhoneDialer.Open("+375257554339");
            }
            catch(Exception e)
            {
                await Shell.Current.DisplayAlert("d", e.Message, "dd");
            }
        }
        public async void AdressCommandExecuted()
        {
            var placemark = new Placemark
            {
                CountryName = "Беларусь",
                AdminArea = null,
                Thoroughfare = "Lyubimova, 12",
                Locality = null
            };
            var options = new MapLaunchOptions { Name = "Lyubimova, 12" };
            try
            {
                await Map.OpenAsync(placemark, options);
            }
            catch(Exception e)
            {
                await Shell.Current.DisplayAlert("d", e.Message, "dd");
            }
        }
    }
}
