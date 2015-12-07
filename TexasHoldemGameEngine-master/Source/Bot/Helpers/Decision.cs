namespace Mogilino.Helpers
{
    using Contracts;
    using TexasHoldem.Logic.Players;

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
