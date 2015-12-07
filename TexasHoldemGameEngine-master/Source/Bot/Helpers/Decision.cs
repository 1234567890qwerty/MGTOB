using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mogilino.Contracts;
using TexasHoldem.Logic.Players;

namespace Mogilino.Helpers
{
    internal abstract class Decision
    {
        protected Decision Successor { get; set; }

        public void SetSuccessor(Decision successor)
        {
            this.Successor = successor;
        }

        public abstract void BasedOnProbabilityDecision(double probability, GetTurnContext context, IBrainHelper brainHelper);
    }
}
