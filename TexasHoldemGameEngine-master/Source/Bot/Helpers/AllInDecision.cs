namespace Mogilino.Helpers
{
    using Common.Constant;
    using Contracts;
    using TexasHoldem.Logic.Players;

    internal class AllInDecision : Decision
    {
        public override void BasedOnProbabilityDecision(double probability, GetTurnContext context, IBrainHelper brainHelper)
        {
            if (probability >= ProbabiltyDecisionConstants.AllIn)
            {
                brainHelper.PlayerAction = PlayerAction.Raise(context.MoneyLeft);
            }
            else if (this.Successor != null)
            {
                this.Successor.BasedOnProbabilityDecision(probability, context, brainHelper);
            }
        }
    }
}
