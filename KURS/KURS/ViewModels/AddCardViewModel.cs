using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using KURS.Models;

namespace KURS.ViewModels
{
    class AddCardViewModel:BaseViewModel
    {
        public  List<CardType> CardTypes { get; }
        private CardType cardType;
        public CardType SelectedCardType
        {
            get => cardType;
            set => SetProperty(ref cardType, value);
        }

        private string number;
        public string Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public AddCardViewModel()
        {
            CardTypes = ds.GetCardTypes();
            SaveCommand = new Command(onSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=(_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void onSave()
        {
            Card newCard = new Card()
            {
                Number = long.Parse(Number),
                CardType = SelectedCardType,
                UserId = App.User.Id
            };
            await ds.AddCardAsync(newCard);
        }
        private bool ValidateSave()
        {
            return long.TryParse(number, out _);
        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
