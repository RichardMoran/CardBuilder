namespace CardBuilder.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using CardBuilder.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cards = this.SetupCards();

            return this.View(cards);
        }

        private static IEnumerable<Card> AddCards(Card definition, int number)
        {
            var cards = new List<Card>();

            for (var i = 0; i < number; i++)
            {
                cards.Add(definition);
            }

            return cards;
        }

        private List<Card> SetupCards()
        {
            // Number of players
            const int Players = 2;

            // Stars
            const int PlusOneStar = 8 * Players;
            const int MinusOneStar = PlusOneStar - Players;
            const int PlusTwoStars = 5 * Players;
            const int MinusTwoStars = PlusTwoStars - Players;
            const int PlusThreeStars = 3 * Players;
            const int MinusThreeStars = PlusThreeStars - Players;

            // Popularity
            const int PlusOnePop = 13 * Players;
            const int MinusOnePop = PlusOnePop - Players;
            const int PlusThreePop = 5 * Players;
            const int MinusThreePop = PlusThreePop - Players;
            const int PlusFivePop = 3 * Players;
            const int MinusFivePop = PlusFivePop - Players;
            const int PlusTenPop = 2 * Players;
            const int MinusTenPop = PlusTenPop - Players;

            // Actions
            const int PlusTwoActions = 1;
            const int PlusTwoCards = 1;
            const int PlusOneActionOneCard = 1;
            const int MinusFivePopPlus1Star = 1;
            const int PlayCardTwice = 1;
            const int MirrorCard = 1;
            const int ForceHandDiscard = 1;
            const int MinusOneStarOrDiscardHand = 1;
            const int MinusFivePopOrDiscardHand = 1;
            const int Blocker = 1;
            const int PassCardsToAnotherPlayer = 1;
            const int TakeCardsFromAnotherPlayer = 1;
            const int TakeUpToFiveFromDiscard = 1;
            const int ImmediatelyApplyTopFiveCards = 1;
            const int OpponentMinusFivePopYouPlusFivePop = 1;
            const int OpponentMinusOneStarYouPlusOneStar = 1;
            const int DiscardCardsDrawUpToFive = 1;
            const int SwapHandsWithAnotherPlayer = 1;
            const int DiscardCardsPlusOnePopPerCard = 1;
            const int EveryoneDrawOneCard = 1;
            const int EveryoneDiscardOneCard = 1;
            const int DrawFourCards = 1;
            const int EveryoneDiscardToZero = 1;

            // Negates
            const int Negates = 8 * Players;

            // Abilities
            const int DrawTwoCardsEveryoneElseDrawsOne = 1 * Players;
            const int SwapCardWithAnotherPlayer = 1 * Players;
            const int SwapFivePopForOneStar = 1 * Players;
            const int SwapOneStarForFivePop = 1 * Players;
            const int DiscardAndDrawOneCard = 1 * Players;
            const int DrawFromDiscardInsteadOfDeck = 1 * Players;
            const int IncreaseHandSize = 1 * Players;

            // Card collection
            var cards = new List<Card>();

            // Add Stars
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "+1 Star", CardType = CardType.Star }, PlusOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-1 Star", CardType = CardType.Star }, MinusOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "+2 Stars", CardType = CardType.Star }, PlusTwoStars));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "-2 Stars", CardType = CardType.Star }, MinusTwoStars));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "+3 Stars", CardType = CardType.Star }, PlusThreeStars));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "-3 Stars", CardType = CardType.Star }, MinusThreeStars));

            // Add Popularity
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "+1 Popularity", CardType = CardType.Popularity }, PlusOnePop));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-1 Popularity", CardType = CardType.Popularity }, MinusOnePop));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "+3 Popularity", CardType = CardType.Popularity }, PlusThreePop));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "-3 Popularity", CardType = CardType.Popularity }, MinusThreePop));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "+5 Popularity", CardType = CardType.Popularity }, PlusFivePop));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "-5 Popularity", CardType = CardType.Popularity }, MinusFivePop));
            cards.AddRange(AddCards(new Card { ActionCost = 5, Action = "+10 Popularity", CardType = CardType.Popularity }, PlusTenPop));
            cards.AddRange(AddCards(new Card { ActionCost = 5, Action = "-10 Popularity", CardType = CardType.Popularity }, MinusTenPop));

            // Add Actions

            // Add Negates
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Negate any card (Play at any time)", CardType = CardType.Negate }, Negates));

            // Add Abilities

            return cards;
        }
    }
}