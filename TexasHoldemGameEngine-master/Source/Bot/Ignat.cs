namespace Mogilino
{
    using System;
    using Contracts;
    using Helpers;
    using MonteCarlo;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Players;

    public class Ignat : BasePlayer
    {
        public Ignat()
            : base()
        {
            this.BrainHelper = new IgnatBrainHelper();
        }

        public override string Name { get; } = "Ignat";

        private IBrainHelper BrainHelper { get; set; }

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            double probability = MonteCarloHelper.GenerateProbabilty(this.FirstCard, this.SecondCard, this.CommunityCards);

            if (context.RoundType == GameRoundType.PreFlop
                || context.RoundType == GameRoundType.Flop
                || context.RoundType == GameRoundType.Turn
                || context.RoundType == GameRoundType.River)
            {
                return this.BrainHelper.PlayerActionDecision(probability, context);
            }
            else
            {
                return PlayerAction.CheckOrCall();
            }
        }
    }
}