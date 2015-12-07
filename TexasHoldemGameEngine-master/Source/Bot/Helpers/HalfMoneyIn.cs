using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mogilino.Common.Constant;
using Mogilino.Contracts;
using TexasHoldem.Logic.Players;

namespace Mogilino.Helpers
{
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
