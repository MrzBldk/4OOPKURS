using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using KURS.Views;

namespace KURS.ViewModels
{
    class SignUpViewModel:BaseViewModel
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

        public Command SignUpCommand { get; }
        public Command TapCommand { get; }
        public SignUpViewModel()
        {
            SignUpCommand = new Command(OnSignupClicked);
            TapCommand = new Command(OnLoginClicked);
        }
        private async void OnSignupClicked(object obj)
        {
            if (ds.SetUser(login, password))
                await Shell.Current.GoToAsync($"//{nameof(CardsPage)}");
            else
                await Shell.Current.DisplayAlert("", "Login is taken", "Cancel");
        }
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
