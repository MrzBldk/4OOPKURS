using System;
using System.Collections.Generic;
using System.Text;

namespace KURS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Card> Cards;
        public User()
        {
            Cards = new List<Card>();
        }
    }
}
