﻿namespace Mogilino
{
    using Contracts;
    using MonteCarlo;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Players;

    public class Ignat : BasePlayer
    {
        public Ignat() : base()
        {
            this.BrainHelper = new IgnatBrainHelper();
        }

        public override string Name { get; } = "Ignat";

        private IBrainHelper BrainHelper { get; set; }

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            double probability = MonteCarloHelper.GenerateProbabilty(this.FirstCard, this.SecondCard, this.CommunityCards);

            if (context.RoundType == GameRoundType.PreFlop)
            {
                return this.BrainHelper.BasedOnProbabilityDecision(probability, context);
            }
            else if (context.RoundType == GameRoundType.Flop)
            {
                return this.BrainHelper.BasedOnProbabilityDecision(probability, context);
            }
            else if (context.RoundType == GameRoundType.Turn)
            {
                return this.BrainHelper.BasedOnProbabilityDecision(probability, context);
            }
            else if (context.RoundType == GameRoundType.River)
            {
                return this.BrainHelper.BasedOnProbabilityDecision(probability, context);
            }

            return PlayerAction.CheckOrCall();
        }
    }
}