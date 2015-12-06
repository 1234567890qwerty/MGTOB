using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Logic.Cards;
using TexasHoldem.Logic.Helpers;

namespace Mogilino
{
    public static class MonteCarloHelper
    {
        public const double TotalGames = 10000;
        static HandEvaluator handEvaluator = new HandEvaluator();
        public static double GenerateProbabilty(Card myCardFirst, Card myCardSecond, IReadOnlyCollection<Card> communityCards)
        {
            var cardsForRemoving = new List<Card>();
            cardsForRemoving.Add(myCardFirst);
            cardsForRemoving.Add(myCardSecond);
            foreach (var item in communityCards)
            {
                cardsForRemoving.Add(item);
            }

            double ourCounter = 0;
            for (int i = 0; i < TotalGames; i++)
            {
                MonteCarloDeck monteCarloDeck = new MonteCarloDeck();
                monteCarloDeck.RemoveSpecificCards(cardsForRemoving);
                var opponentFirstCard = monteCarloDeck.GetNextCard();
                var opponentSecondCard = monteCarloDeck.GetNextCard();

                List<Card> monteCarloCommunityCards = new List<Card>();
                for (int j = 0; j < 5 - communityCards.Count; j++)
                {
                    monteCarloCommunityCards.Add(monteCarloDeck.GetNextCard());
                }

                List<Card> ourHandForEavluation = new List<Card>();
                ourHandForEavluation.Add(myCardFirst);
                ourHandForEavluation.Add(myCardSecond);
                ourHandForEavluation.AddRange(monteCarloCommunityCards);
                var ourHandStrength = handEvaluator.GetBestHand(ourHandForEavluation);

                List<Card> opponentHandForEavluation = new List<Card>();
                opponentHandForEavluation.Add(opponentFirstCard);
                opponentHandForEavluation.Add(opponentSecondCard);
                opponentHandForEavluation.AddRange(monteCarloCommunityCards);
                var opponentHandStrength = handEvaluator.GetBestHand(opponentHandForEavluation);

                if (ourHandStrength.CompareTo(opponentHandStrength) > 0)
                {
                    ourCounter++;
                }
            }

            double result = ourCounter / TotalGames;
            return result;
        }
    }
}
