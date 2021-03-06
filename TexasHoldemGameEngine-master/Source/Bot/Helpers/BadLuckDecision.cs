﻿namespace Mogilino.Helpers
{
    using Common.Constant;
    using Contracts;
    using TexasHoldem.Logic.Players;

    internal class BadLuckDecision : Decision
    {
        public override void BasedOnProbabilityDecision(double probability, GetTurnContext context, IBrainHelper brainHelper)
        {
            if (probability < ProbabiltyDecisionConstants.CheckCall)
            {
                brainHelper.PlayerAction = PlayerAction.Fold();
            }
            else if (this.Successor != null)
            {
                this.Successor.BasedOnProbabilityDecision(probability, context, brainHelper);
            }
        }
    }
}
