using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TexasHoldem.Logic;
using TexasHoldem.Logic.Players;

namespace Bot
{
    public class Bot : BasePlayer
    {
        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            if (context.RoundType == GameRoundType.PreFlop)
            {
            }
            else if (context.RoundType == GameRoundType.Flop)
            {
            }
            else if (context.RoundType == GameRoundType.Turn)
            {
            }
            else if (context.RoundType == GameRoundType.River)
            {
            }
        }
    }
}
