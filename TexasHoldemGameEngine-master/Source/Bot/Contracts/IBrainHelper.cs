namespace Mogilino.Contracts
{
    using TexasHoldem.Logic.Players;

    public interface IBrainHelper
    {
        PlayerAction BasedOnProbabilityDecision(double probability, GetTurnContext context);
    }
}