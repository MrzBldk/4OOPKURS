using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using KURS.Views;

namespace KURS.ViewModels
{
    class SignUpViewModel:BaseViewModel
    {
        public Command SignUpCommand { get; }
        public Command TapCommand { get; }
        public SignUpViewModel()
        {
            SignUpCommand = new Command(OnSignupClicked);
            TapCommand = new Command(OnLoginClicked);
        }
        private async void OnSignupClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(CardsPage)}");
        }
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
