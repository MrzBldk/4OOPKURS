using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Essentials;

using KURS.Views;

namespace KURS.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string login;
        private string password;
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public Command LoginCommand { get; }
        public Command TapCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            TapCommand = new Command(OnSignupClicked);
        }
        private async void OnLoginClicked(object obj)
        {
            if (ds.GetUser(login, password))
                await Shell.Current.GoToAsync($"//{nameof(CardsPage)}");
            else
            {
                try
                {
                    var duration = TimeSpan.FromSeconds(1);
                    Vibration.Vibrate(duration);
                }
                catch (FeatureNotSupportedException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                await Shell.Current.DisplayAlert("", "Wrong login or password", "Cancel"); 
            }
        }
        private async void OnSignupClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }
    }
}
