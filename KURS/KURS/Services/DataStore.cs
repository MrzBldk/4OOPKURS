using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using KURS.Models;
using System.Linq;
using System.Threading.Tasks;

namespace KURS.Services
{
    class DataStore
    {
        KursContext db;
        public List<Card> Cards;

        public DataStore()
        {
            db = new KursContext(DependencyService.Get<IPath>().GetDatabasePath("Kurs.db"));
            //db.CardTypes.Load();
            //db.Users.Load();
            //db.Cards.Load();
            Cards = db.Cards.Where(x => x.User.Login == "MrzBldk").ToList();
        }

        public async Task<int> AddCardAsync(Card card)
        {
            db.Cards.Add(card);
            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateCardAsync(Card card)
        {
            Card old = db.Cards.Find(card.Id);
            db.Cards.Remove(old);
            db.Cards.Add(card);
            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteCardAsync(int id)
        {
            Card old = db.Cards.Find(id);
            db.Cards.Remove(old);
            return await db.SaveChangesAsync();
        }
        public async ValueTask<Card> GetCardAsync(int id)
        {
            return await db.Cards.FindAsync(id);
        }
        public async Task<List<Card>> GetCardsAsync()
        {
            return await Task.FromResult(Cards);
        }
    }
}
