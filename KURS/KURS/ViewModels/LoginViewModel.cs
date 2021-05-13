using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using KURS.Views;

namespace KURS.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command TapCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            TapCommand = new Command(OnSignupClicked);
        }
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(CardsPage)}");
        }
        private async void OnSignupClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }
    }
}
