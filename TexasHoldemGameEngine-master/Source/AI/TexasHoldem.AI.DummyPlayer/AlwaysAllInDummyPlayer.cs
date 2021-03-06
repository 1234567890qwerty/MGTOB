﻿namespace TexasHoldem.AI.DummyPlayer
{
    using System;

    using TexasHoldem.Logic.Players;

    public class AlwaysAllInDummyPlayer : BasePlayer
    {
        public override string Name { get; } = "AlwaysAllInDummyPlayer";

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            if (context.MoneyLeft > 0)
            {
                return PlayerAction.Raise(context.MoneyLeft);
            }
            else
            {
                return PlayerAction.CheckOrCall();
            }
        }
    }
}
