namespace Mogilino.Helpers
{
    using Contracts;
    using TexasHoldem.Logic.Players;

    public class IgnatBrainHelper : IBrainHelper
    {
        public PlayerAction PlayerAction { get; set; }

        public PlayerAction PlayerActionDecision(double probability, GetTurnContext context)
        {
            AllInDecision allIn = new AllInDecision();
            HalfMoneyIn halfMoneyIn = new HalfMoneyIn();
            RaiseDecision raise = new RaiseDecision();
            SmallRaiseDecision smallRaise = new SmallRaiseDecision();
            CheckCallDecision checkCall = new CheckCallDecision();
            BadLuckDecision badLuck = new BadLuckDecision();

            allIn.SetSuccessor(halfMoneyIn);
            halfMoneyIn.SetSuccessor(raise);
            raise.SetSuccessor(smallRaise);
            smallRaise.SetSuccessor(checkCall);
            checkCall.SetSuccessor(badLuck);


            allIn.BasedOnProbabilityDecision(probability, context, this);

            return this.PlayerAction;
        }
    }
}
