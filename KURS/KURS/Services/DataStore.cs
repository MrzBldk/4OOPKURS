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
using System.IO;
using Xamarin.Essentials;

namespace KURS.Services
{
    class DataStore
    {
        KursContext db;
        public List<Card> Cards;

        public DataStore()
        {
            db = new KursContext(DependencyService.Get<IPath>().GetDatabasePath("Kurs.db"));
            if (db.CardTypes.Count() == 0)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    for (int i = 1; i < 15; i++)
                    {
                        string[] tn = { "O'STIN", "Виталюр", "Рублёвский", "Санта", "Минсктранс", "Белфармация", "Остров Чистоты", "MEGATOP", "Соседи", "Магия", "Prostore", "5 элемент", "MINIMAX", "Евроопт" };
                        byte[] data;
                        Stream s = FileSystem.OpenAppPackageFileAsync($"{i}.png").Result;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            s.CopyTo(ms);
                            data = ms.ToArray();
                            ms.Dispose();
                        }
                        CardType cd1 = new CardType { TypeName = tn[i-1], Photo = data };
                        db.CardTypes.Add(cd1);
                        db.SaveChanges();
                    }
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    for (int i = 1; i < 15; i++)
                    {
                        string[] tn = { "O'STIN", "Виталюр", "Рублёвский", "Санта", "Минсктранс", "Белфармация", "Остров Чистоты", "MEGATOP", "Соседи", "Магия", "Prostore", "5 элемент", "MINIMAX", "Евроопт" };
                        byte[] data;
                        Stream s = FileSystem.OpenAppPackageFileAsync($"Assets/{i}.png").Result;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            s.CopyTo(ms);
                            data = ms.ToArray();
                            ms.Dispose();
                        }
                        CardType cd1 = new CardType { TypeName = tn[i - 1], Photo = data };
                        db.CardTypes.Add(cd1);
                        db.SaveChanges();
                    }
                }
            }
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
        public async Task ChangePassword(string pas)
        {
            User user = db.Users.Where(x => x.Login == App.User.Login).FirstOrDefault();
            user.Password = pas;
            await db.SaveChangesAsync();
            App.User = user;
        }
    }
}
