namespace TexasHoldem.AI.DummyPlayer
{
    using System;

    using TexasHoldem.Logic.Players;

    public class AlwaysCallDummyPlayer : BasePlayer
    {
        public override string Name { get; } = "AlwaysCallDummyPlayer";

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            return PlayerAction.CheckOrCall();
        }
    }
}
