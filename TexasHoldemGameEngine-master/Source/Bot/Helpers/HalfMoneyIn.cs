namespace Mogilino.Helpers
{
    using Common.Constant;
    using Contracts;
    using TexasHoldem.Logic.Players;

    internal class HalfMoneyIn : Decision
    {
        public override void BasedOnProbabilityDecision(double probability, GetTurnContext context, IBrainHelper brainHelper)
        {
            if (probability >= ProbabiltyDecisionConstants.HalfMoneyIn)
            {
                brainHelper.PlayerAction = PlayerAction.Raise(context.MoneyLeft / 2);
            }
            else if (this.Successor != null)
            {
                this.Successor.BasedOnProbabilityDecision(probability, context, brainHelper);
            }
        }
    }
}
