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
            var cards = SetupCards();

            return this.View(cards);
        }

        private static List<Card> SetupCards()
        {
            // Number of players
            const int Players = 2;

            // Stars
            const int PlusOneStar = 5 * Players;
            const int MinusOneStar = PlusOneStar - Players;
            const int PlusTwoStars = 3 * Players;
            const int MinusTwoStars = PlusTwoStars - Players;
            const int PlusThreeStars = 2 * Players;
            const int MinusThreeStars = PlusThreeStars - Players;

            // Popularity
            const int PlusOnePop = 8 * Players;
            const int MinusOnePop = PlusOnePop - Players;
            const int PlusThreePop = 5 * Players;
            const int MinusThreePop = PlusThreePop - Players;
            const int PlusFivePop = 3 * Players;
            const int MinusFivePop = PlusFivePop - Players;
            const int PlusTenPop = 2 * Players;
            const int MinusTenPop = PlusTenPop - Players;

            // Actions
            const int PlusTwoActions = 2 * Players;
            const int PlusTwoCards = 2 * Players;
            const int PlusOneActionOneCard = 2 * Players;
            const int MinusFivePopPlusOneStar = 1 * Players;
            const int PlayCardTwice = 1 * Players;
            const int MirrorCard = 1 * Players;
            const int ForceHandDiscard = 1 * Players;
            const int MinusOneStarOrDiscardHand = 1 * Players;
            const int MinusFivePopOrDiscardHand = 1 * Players;
            const int PassCardsToAnotherPlayer = 2 * Players;
            const int TakeCardsFromAnotherPlayer = 1 * Players;
            const int TakeUpToFiveFromDiscard = 1 * Players;
            const int ImmediatelyApplyTopFiveCards = 1 * Players;
            const int OpponentMinusFivePopYouPlusFivePop = 1 * Players;
            const int OpponentMinusOneStarYouPlusOneStar = 1 * Players;
            const int DiscardCardsDrawUpToFive = 1 * Players;
            const int SwapHandsWithAnotherPlayer = 1 * Players;
            const int EveryoneDrawOneCard = 2 * Players;
            const int EveryoneDiscardOneCard = 2 * Players;
            const int DrawFourCards = 2 * Players;
            const int EveryoneDiscardToZero = 1 * Players;

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
            const int DiscardCardsPlusOnePopPerCard = 1 * Players;

            // Blockers
            const int Blockers = 1 * Players;

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
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "+2 Actions", CardType = CardType.Action }, PlusTwoActions));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "+2 Cards", CardType = CardType.Action }, PlusTwoCards));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "+1 Action +1 Card", CardType = CardType.Action }, PlusOneActionOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-5 Popularity +1 Star", CardType = CardType.Action }, MinusFivePopPlusOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Play any card in your hand twice", CardType = CardType.Action }, PlayCardTwice));
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Play immediately after an opponent plays a card. The effects of that card immediately apply to you too.", CardType = CardType.Action }, MirrorCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Discard your hand.", CardType = CardType.Action }, ForceHandDiscard));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "-1 Star OR discard your hand.", CardType = CardType.Action }, MinusOneStarOrDiscardHand));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "-5 Popularity OR discard your hand.", CardType = CardType.Action }, MinusFivePopOrDiscardHand));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Give a card to another player.", CardType = CardType.Action }, PassCardsToAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Take a card at random from another player.", CardType = CardType.Action }, TakeCardsFromAnotherPlayer));
            //// cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Draw up to five cards from the top of the discard pile.", CardType = CardType.Action }, TakeUpToFiveFromDiscard));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Draw five cards, immediately apply all effects to yourself.", CardType = CardType.Action }, ImmediatelyApplyTopFiveCards));
            //// cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Opponent -5 popularity, you +5 popularity", CardType = CardType.Action }, OpponentMinusFivePopYouPlusFivePop));
            //// cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Opponent -1 star, you +1 star.", CardType = CardType.Action }, OpponentMinusOneStarYouPlusOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Discard as many cards as you like, draw back up to five.", CardType = CardType.Action }, DiscardCardsDrawUpToFive));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Swap hands with another player of your choice", CardType = CardType.Action }, SwapHandsWithAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Everyone +1 card.", CardType = CardType.Action }, EveryoneDrawOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Everyone -1 card.", CardType = CardType.Action }, EveryoneDiscardOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "+4 cards", CardType = CardType.Action }, DrawFourCards));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "Everyone discard all cards.", CardType = CardType.Action }, EveryoneDiscardToZero));

            // Add Negates
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Negate any card (Play at any time)", CardType = CardType.Negate }, Negates));

            // Add Abilities
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "+2 cards, every other player immediately +1 card. Keep in front of you. Use up to once per turn.", CardType = CardType.Ability }, DrawTwoCardsEveryoneElseDrawsOne));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Swap one card with another player. Keep in front of you. Use up to once per turn.", CardType = CardType.Ability }, SwapCardWithAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-5 Popularity, +1 Star. Keep in front of you. Use up to once per turn.", CardType = CardType.Ability }, SwapFivePopForOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-1 Star, +5 Popularity. Keep in front of you. Use up to once per turn.", CardType = CardType.Ability }, SwapOneStarForFivePop));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Discard one card, +1 card. Keep in front of you. Use up to once per turn.", CardType = CardType.Ability }, DiscardAndDrawOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Draw the top card from the discard pile. Keep in front of you. Use up to once per turn.", CardType = CardType.Ability }, DrawFromDiscardInsteadOfDeck));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Hand size +1. Keep in front of you. Use up to once per turn.", CardType = CardType.Ability }, IncreaseHandSize));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Discard any number of cards, +1 popularity per card discarded. Keep in front of you. Use up to once per turn.", CardType = CardType.Ability }, DiscardCardsPlusOnePopPerCard));

            // Add Blockers
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Blocker - Cannot be played. Cannot be discarded.", CardType = CardType.Blocker }, Blockers));

            return cards;
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
    }
}