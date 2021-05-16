using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Xamarin.Forms;

namespace KURS.ViewModels
{
    [QueryProperty(nameof(CardId), nameof(CardId))]
    class CardDetailViewModel :BaseViewModel
    {
        private int cardId;
        private long number;
        public int Id { get; set; }

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
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load card"); 
            }
        }
    }
}
