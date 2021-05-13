using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using KURS.Views;

namespace KURS.ViewModels
{
    class CardsViewModel:BaseViewModel
    {
        public Command AddCardCommand { get; }

        public CardsViewModel()
        {
            Title = "Browse";
            AddCardCommand = new Command(OnAddCard);
        }

        private async void OnAddCard(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddCardPage));
        }
    }
}
