namespace Mogilino.Helpers
{
    using Common.Constant;
    using Contracts;
    using TexasHoldem.Logic.Players;

    internal class RaiseDecision : Decision
    {
        public override void BasedOnProbabilityDecision(double probability, GetTurnContext context, IBrainHelper brainHelper)
        {
            if (probability >= ProbabiltyDecisionConstants.Raise)
            {
                brainHelper.PlayerAction = PlayerAction.Raise(context.CurrentPot);
            }
            else if (this.Successor != null)
            {
                this.Successor.BasedOnProbabilityDecision(probability, context, brainHelper);
            }
        }
    }
}
