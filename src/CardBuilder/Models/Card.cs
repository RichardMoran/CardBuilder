using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardBuilder.Models
{
    public class Card
    {
        public int ActionCost { get; set; }
        public string Action { get; set; }
        public CardType CardType { get; set; }
    }

    public enum CardType
    {
        Ability,
        Popularity,
        Review,
        Action
    }
}