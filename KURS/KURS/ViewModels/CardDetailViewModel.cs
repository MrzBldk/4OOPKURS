using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Xamarin.Forms;
using System.Threading.Tasks;
using KURS.Views;

namespace KURS.ViewModels
{
    [QueryProperty(nameof(CardId), nameof(CardId))]
    class CardDetailViewModel :BaseViewModel
    {
        private int cardId;
        private long number;
        public byte[] photo;

        public int Id { get; set; }

        public byte[] Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }
        public long Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }
        public int CardId
        {
            get
            {
                return cardId;
            }
            set
            {
                cardId = value;
                LoadCardId(value);
            }
        }
        public async void LoadCardId(int cardId)
        {
            try
            {
                var item = await ds.GetCardAsync(cardId);
                Id = item.Id;
                Number = item.Number;
                Photo = item.CardType.Photo;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                Debug.WriteLine("Failed to load card");
            }
        }

        public CardDetailViewModel()
        {
            DeleteCardCommand = new Command(async () => await ExecuteDeleteCardCommand());
        }
        public Command DeleteCardCommand { get; }

        async Task ExecuteDeleteCardCommand()
        {
            await ds.DeleteCardAsync(Id);
            await Shell.Current.GoToAsync("..");
        }
    }
}
