using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardBuilder.Controllers
{
    using CardBuilder.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cards = this.SetupCards();

            return this.View(cards);
        }

        private List<Card> SetupCards()
        {
            const int PlusOnePops = 5;
            const int MinusOnePops = 4;

            var cards = new List<Card>();

            cards.AddRange(this.AddCards(new Card { ActionCost = 1, Action = "+1 Popularity", CardType = CardType.Popularity }, PlusOnePops));
            cards.AddRange(this.AddCards(new Card { ActionCost = 1, Action = "-1 Popularity", CardType = CardType.Popularity }, MinusOnePops));

            return cards;
        }

        private IEnumerable<Card> AddCards(Card definition, int number)
        {
            var cards = new List<Card>();

            for (var i = 0; i < number; i++)
            {
                cards.Add(definition);
            }

            return cards;
        }
    }
}