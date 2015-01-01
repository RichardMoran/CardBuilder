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
            // Stars
            const int PlusOneStar = 12;
            const int MinusOneStar = 6;
            const int PlusTwoStars = 4;
            const int MinusTwoStars = 2;
            const int PlusThreeStars = 0;
            const int MinusThreeStars = 0;

            // Popularity
            const int PlusOnePop = 24;
            const int MinusOnePop = 12;
            const int PlusThreePop = 10;
            const int MinusThreePop = 5;
            const int PlusFivePop = 2;
            const int MinusFivePop = 1;
            const int PlusTenPop = 0;
            const int MinusTenPop = 0;

            // Actions
            const int PlusTwoActions = 6;
            const int PlusTwoCards = 6;
            const int PlusOneActionOneCard = 6;
            const int MinusFivePopPlusOneStar = 2;
            const int PlayCardTwice = 2;
            const int ForceHandDiscard = 2;
            const int MinusOneStarOrDiscardHand = 1;
            const int MinusFivePopOrDiscardHand = 1;
            const int PassCardsToAnotherPlayer = 0;
            const int TakeCardsFromAnotherPlayer = 2;
            const int TakeUpToFiveFromDiscard = 0;
            const int ImmediatelyApplyTopThreeCards = 2;
            const int ImmediatelyApplyTopFiveCards = 2;
            const int OpponentMinusThreePopYouPlusThreePop = 2;
            const int OpponentMinusOneStarYouPlusOneStar = 2;
            const int DiscardCardsDrawUpToFive = 2;
            const int SwapHandsWithAnotherPlayer = 0;
            const int EveryoneDrawOneCard = 2;
            const int EveryoneDiscardOneCard = 2;
            const int PlusFourCards = 2;
            const int EveryoneDiscardToZero = 1;
            const int StealAbility = 1;

            // Interrupts
            const int Negates = 4;
            const int MirrorCard = 4;
            const int EffectAppliesToAnotherPlayer = 4;
            const int EffectAppliesToYouInstead = 4;

            // Abilities
            const int DrawTwoCardsEveryoneElseDrawsOne = 1;
            const int SwapCardWithAnotherPlayer = 1;
            const int SwapFivePopForOneStar = 1;
            const int SwapOneStarForFivePop = 1;
            const int DiscardAndDrawOneCard = 0;
            const int DrawFromDiscardInsteadOfDeck = 1;
            const int IncreaseHandSize = 1;
            const int DiscardCardsPlusOnePopPerCard = 1;
            const int HaveTwoAbilities = 1;
            const int DrawAndApplyTopCard = 1;

            // Blockers
            const int Blockers = 0;

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
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "Play any card in your hand twice (second time is free)", CardType = CardType.Action }, PlayCardTwice));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You/opponent discard your/their hand.", CardType = CardType.Action }, ForceHandDiscard));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "Opponent -1 Star OR discard their hand.", CardType = CardType.Action }, MinusOneStarOrDiscardHand));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "Opponent -5 Popularity OR discard their hand.", CardType = CardType.Action }, MinusFivePopOrDiscardHand));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You/opponent must give a card to another player of your choice.", CardType = CardType.Action }, PassCardsToAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You may take a card at random from another player.", CardType = CardType.Action }, TakeCardsFromAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "You may draw up to five cards from the top of the discard pile.", CardType = CardType.Action }, TakeUpToFiveFromDiscard));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You/opponent draws three cards and must immediately apply all effects to themself.", CardType = CardType.Action }, ImmediatelyApplyTopThreeCards));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "You/opponent draws five cards and must immediately apply all effects to themself.", CardType = CardType.Action }, ImmediatelyApplyTopFiveCards));
            cards.AddRange(AddCards(new Card { ActionCost = 4, Action = "Opponent -3 popularity, you +3 popularity", CardType = CardType.Action }, OpponentMinusThreePopYouPlusThreePop));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "Opponent -1 star, you +1 star.", CardType = CardType.Action }, OpponentMinusOneStarYouPlusOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 2, Action = "You may discard as many cards as they like, and draw back up to your hand limit immediately.", CardType = CardType.Action }, DiscardCardsDrawUpToFive));
            cards.AddRange(AddCards(new Card { ActionCost = 4, Action = "You/opponent swap hands with another player of your choice", CardType = CardType.Action }, SwapHandsWithAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Everyone +1 card.", CardType = CardType.Action }, EveryoneDrawOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Everyone -1 card.", CardType = CardType.Action }, EveryoneDiscardOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 3, Action = "+4 cards", CardType = CardType.Action }, PlusFourCards));
            cards.AddRange(AddCards(new Card { ActionCost = 4, Action = "Everyone discard all cards.", CardType = CardType.Action }, EveryoneDiscardToZero));
            cards.AddRange(AddCards(new Card { ActionCost = 5, Action = "Steal another player's ability and make it your ability.", CardType = CardType.Action }, StealAbility));

            // Add Interrupts
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Play immediately after an opponent plays a card. The card your opponent played has no effect.", CardType = CardType.Interrupt }, Negates));
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Play immediately after an opponent plays a card. The effects of that card immediately apply to you too.", CardType = CardType.Interrupt }, MirrorCard));
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Play immediately after an opponent plays a card that negatively affects you. The effects of that card immediately apply to another player instead of you.", CardType = CardType.Interrupt }, EffectAppliesToAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 0, Action = "Play immediately after an opponent plays a card. The effects of that card immediately apply to you instead of whoever it would normally apply to.", CardType = CardType.Interrupt }, EffectAppliesToYouInstead));

            // Add Abilities
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "+2 cards, every other player immediately +1 card. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DrawTwoCardsEveryoneElseDrawsOne));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Swap one card with another player. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, SwapCardWithAnotherPlayer));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-5 Popularity, +1 Star. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, SwapFivePopForOneStar));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "-1 Star, +5 Popularity. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, SwapOneStarForFivePop));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Discard one card, +1 card. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DiscardAndDrawOneCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Draw the top card from the discard pile. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DrawFromDiscardInsteadOfDeck));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Hand size +1. (Keep this card in front of you.)", CardType = CardType.Ability }, IncreaseHandSize));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Discard any number of cards, +1 popularity per card discarded. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DiscardCardsPlusOnePopPerCard));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "With this card in front of you, you may have two active abilities (other than this one) instead of one. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, HaveTwoAbilities));
            cards.AddRange(AddCards(new Card { ActionCost = 1, Action = "Draw the top card from the deck, its effects immediately apply to you. (Keep this card in front of you. Use up to once per turn.)", CardType = CardType.Ability }, DrawAndApplyTopCard));

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