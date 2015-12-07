namespace Mogilino.Helpers
{
    using Contracts;
    using TexasHoldem.Logic.Players;

    public class IgnatBrainHelper : IBrainHelper
    {
        private const double AllInProbability = 0.95;
        private const double HalfMoneyAllInProbability = 0.85;
        private const double RaiseNumberProbability = 0.75;
        private const double SmallRaiseProbability = 0.65;
        private const double CheckCallProbability = 0.5;

        public PlayerAction BasedOnProbabilityDecision(double probability, GetTurnContext context)
        {
            if (probability >= AllInProbability)
            {
                return PlayerAction.Raise(context.MoneyLeft);
            }
            else if (probability >= HalfMoneyAllInProbability)
            {
                return PlayerAction.Raise(context.MoneyLeft / 2);
            }
            else if (probability >= HalfMoneyAllInProbability)
            {
                return PlayerAction.Raise(context.CurrentPot);
            }
            else if (probability >= SmallRaiseProbability)
            {
                return PlayerAction.Raise(context.CurrentPot/2);
            }
            else if (probability >= CheckCallProbability)
            {
                return PlayerAction.CheckOrCall();
            }
            else
            {
                return PlayerAction.Fold();
            }
        }
    }
}
