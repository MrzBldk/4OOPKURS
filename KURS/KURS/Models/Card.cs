using System;
using System.Collections.Generic;
using System.Text;

namespace KURS.Models
{
    public class Card
    {
        public int Id { get; set; }
        public long Number { get; set; }

        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
