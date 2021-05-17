using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Cards = db.Cards.Include(p=>p.CardType).Where(x => x.User.Login == "MrzBldk").ToList();
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
            return await db.Cards.Include(x => x.CardType).Where(x => x.Id == id).FirstAsync();
            //return await db.Cards.FindAsync(id);
        }
        public async Task<List<Card>> GetCardsAsync()
        {
            Cards = db.Cards.Include(x=>x.CardType).Where(x => x.UserId == App.User.Id).ToList();
            return await Task.FromResult(Cards);
        }
        public List<CardType> GetCardTypes()
        {
            return db.CardTypes.Where(x => true).ToList();
        }
        public bool GetUser(string log, string pas)
        {
            User user;
            if ((user = db.Users.Where(x => x.Login == log && x.Password == pas).FirstOrDefault()) != null)
            {
                App.User = user;
                return true;
            }
            return false;
        }
        public bool SetUser(string log, string pas)
        {
            User user;
            if ((db.Users.Where(x => x.Login == log).FirstOrDefault()) != null)
            {
                return false;
            }
            db.Users.Add(user = new User() { Login = log, Password = pas });
            db.SaveChanges();
            App.User = user;
            return true;
        }
    }
}
