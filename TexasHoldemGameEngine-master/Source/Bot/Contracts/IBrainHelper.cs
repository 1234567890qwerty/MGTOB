namespace Mogilino.Contracts
{
    using TexasHoldem.Logic.Players;

    public interface IBrainHelper
    {
        PlayerAction PlayerAction { get; set; }

        PlayerAction PlayerActionDecision(double probability, GetTurnContext context);
    }
}