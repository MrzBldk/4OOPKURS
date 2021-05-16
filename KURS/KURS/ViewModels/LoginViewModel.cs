using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;

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
        private string Password
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
            if (login != "MrzBldk" && Password != "P3z4e")
                await Shell.Current.DisplayAlert("", "Wrong login or password ", "Cancel");
            else
                await Shell.Current.GoToAsync($"//{nameof(CardsPage)}");
        }
        private async void OnSignupClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }
    }
}
