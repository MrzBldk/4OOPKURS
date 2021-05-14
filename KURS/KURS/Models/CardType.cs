using System;
using System.Collections.Generic;
using System.Text;

namespace KURS.Models
{
    public class CardType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public byte[] Photo { get; set; }

        public ICollection<Card> Cards;
        public CardType()
        {
            Cards = new List<Card>();
        }
        public override string ToString()
        {
            return TypeName;
        }
    }
}
