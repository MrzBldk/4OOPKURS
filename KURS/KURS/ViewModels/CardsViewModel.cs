using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

using KURS.Views;
using KURS.Models;
using KURS.Services;

namespace KURS.ViewModels
{
    class CardsViewModel : BaseViewModel
    {
        private Card _selectedCard;

        public ObservableCollection<Card> Cards { get; }
        public Command LoadCardsCommand { get; }
        public Command AddCardCommand { get; }
        DataStore ds = new DataStore();

        public CardsViewModel()
        {
            Title = "Browse";
            Cards = new ObservableCollection<Card>();
            LoadCardsCommand = new Command(async () => await ExecuteLoadCardsCommand());
            AddCardCommand = new Command(OnAddCard);
        }

        async Task ExecuteLoadCardsCommand()
        {
            IsBusy = true;
            try
            {
                Cards.Clear();
                var cards = await ds.GetCardsAsync();
                foreach (var card in cards)
                    Cards.Add(card);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void  OnAppearing()
        {
            IsBusy = true;
            SelectedCard = null;
        }

        public Card SelectedCard
        {
            get => _selectedCard;
            set
            {
                SetProperty(ref _selectedCard, value);
                OnCardSelected(value);
            }
        }

        async void OnCardSelected(Card card)
        {
            if (card == null)
                return;
            await Shell.Current.GoToAsync(nameof(CardDetailPage));
        }

        private async void OnAddCard(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddCardPage));
        }
    }
}
