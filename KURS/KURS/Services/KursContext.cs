using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using KURS.Models;

namespace KURS.Services
{
    public class KursContext : DbContext
    {
        public DbSet<User> Users;
        public DbSet<Card> Cards;
        public DbSet<CardType> CardTypes;

        private string _databasePath;
        public KursContext(string databasePath)
        {
            Database.EnsureCreated();
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

    }
}
