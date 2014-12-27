namespace CardBuilder.Controllers
{
    using System.Collections.Generic;
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
            const int PlusOneStar = 8 * Players;
            const int MinusOneStar = PlusOneStar - Players;
            const int PlusTwoStars = 1 * Players;
            const int MinusTwoStars = PlusTwoStars - Players;
            const int PlusThreeStars = 0 * Players;
            const int MinusThreeStars = PlusThreeStars - Players;

            // Popularity
            const int PlusOnePop = 15 * Players;
            const int MinusOnePop = PlusOnePop - Players;
            const int PlusThreePop = 5 * Players;
            const int MinusThreePop = PlusThreePop - Players;
            const int PlusFivePop = 1 * Players;
            const int MinusFivePop = PlusFivePop - Players;
            const int PlusTenPop = 0 * Players;
            const int MinusTenPop = PlusTenPop - Players;

            // Actions
            const int PlusTwoActions = 5 * Players;
            const int PlusTwoCards = 5 * Players;
            const int PlusOneActionOneCard = 5 * Players;
            const int MinusFivePopPlusOneStar = 1 * Players;
            const int PlayCardTwice = 2 * Players;
            const int MirrorCard = 2 * Players;
            const int ForceHandDiscard = 1 * Players;
            const int MinusOneStarOrDiscardHand = 2 * Players;
            const int MinusFivePopOrDiscardHand = 2 * Players;
            const int PassCardsToAnotherPlayer = 1 * Players;
            const int TakeCardsFromAnotherPlayer = 1 * Players;
            const int TakeUpToFiveFromDiscard = 0 * Players;
            const int ImmediatelyApplyTopThreeCards = 4 * Players;
            const int ImmediatelyApplyTopFiveCards = 2 * Players;
            const int OpponentMinusThreePopYouPlusThreePop = 3 * Players;
            const int OpponentMinusOneStarYouPlusOneStar = 2 * Players;
            const int DiscardCardsDrawUpToFive = 1 * Players;
            const int SwapHandsWithAnotherPlayer = 1 * Players;
            const int EveryoneDrawOneCard = 2 * Players;
            const int EveryoneDiscardOneCard = 2 * Players;
            const int PlusFourCards = 4 * Players;
            const int EveryoneDiscardToZero = 1 * Players;

            // Negates
            const int Negates = 5 * Players;

            // Abilities
            const int DrawTwoCardsEveryoneElseDrawsOne = 1 * Players;
            const int SwapCardWithAnotherPlayer = 1 * Players;
            const int SwapFivePopForOneStar = 1 * Players;
            const int SwapOneStarForFivePop = 1 * Players;
            const int DiscardAndDrawOneCard = 0 * Players;
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
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Play any card in your hand twice (second time is free)", CardType = CardType.Action }, PlayCardTwice));
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Play immediately after an opponent plays a card. The effects of that card immediately apply to you too.", CardType = CardType.Action }, MirrorCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "You/opponent discard your/their hand.", CardType = CardType.Action }, ForceHandDiscard));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Opponent -1 Star OR discard their hand.", CardType = CardType.Action }, MinusOneStarOrDiscardHand));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Opponent -5 Popularity OR discard their hand.", CardType = CardType.Action }, MinusFivePopOrDiscardHand));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "You/opponent must give a card to another player of your choice.", CardType = CardType.Action }, PassCardsToAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "You may take a card at random from another player.", CardType = CardType.Action }, TakeCardsFromAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You may draw up to five cards from the top of the discard pile.", CardType = CardType.Action }, TakeUpToFiveFromDiscard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "You/opponent draws three cards and must immediately apply all effects to themself.", CardType = CardType.Action }, ImmediatelyApplyTopThreeCards));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You/opponent draws five cards and must immediately apply all effects to themself.", CardType = CardType.Action }, ImmediatelyApplyTopFiveCards));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Opponent -3 popularity, you +3 popularity", CardType = CardType.Action }, OpponentMinusThreePopYouPlusThreePop));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Opponent -1 star, you +1 star.", CardType = CardType.Action }, OpponentMinusOneStarYouPlusOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You may discard as many cards as they like, and draw back up to your hand limit immediately.", CardType = CardType.Action }, DiscardCardsDrawUpToFive));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You/opponent swap hands with another player of your choice", CardType = CardType.Action }, SwapHandsWithAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Everyone +1 card.", CardType = CardType.Action }, EveryoneDrawOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Everyone -1 card.", CardType = CardType.Action }, EveryoneDiscardOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "+4 cards", CardType = CardType.Action }, PlusFourCards));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "Everyone discard all cards.", CardType = CardType.Action }, EveryoneDiscardToZero));

            // Add Negates
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Negate any card (Play at any time)", CardType = CardType.Negate }, Negates));

            // Add Abilities
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "+2 cards, every other player immediately +1 card. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DrawTwoCardsEveryoneElseDrawsOne));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Swap one card with another player. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, SwapCardWithAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-5 Popularity, +1 Star. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, SwapFivePopForOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-1 Star, +5 Popularity. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, SwapOneStarForFivePop));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Discard one card, +1 card. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DiscardAndDrawOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Draw the top card from the discard pile. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DrawFromDiscardInsteadOfDeck));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Hand size +1. (Keep this card in front of you.)", CardType = CardType.Ability }, IncreaseHandSize));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Discard any number of cards, +1 popularity per card discarded. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DiscardCardsPlusOnePopPerCard));

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