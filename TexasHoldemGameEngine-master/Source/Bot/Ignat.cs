using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TexasHoldem.Logic;
using TexasHoldem.Logic.Extensions;
using TexasHoldem.Logic.Players;

namespace Mogilino
{
    public class Ignat : BasePlayer
    {
        static Dictionary<string, int> preflopCount = new Dictionary<string, int>();
        static Dictionary<string, int> flopCount = new Dictionary<string, int>();


        public override string Name { get; } = "Ignat";

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            double probability = MonteCarloHelper.GenerateProbabilty(this.FirstCard, this.SecondCard, this.CommunityCards);

            #region Preflop
            if (context.RoundType == GameRoundType.PreFlop)
            {
                if (context.MoneyToCall <= context.SmallBlind * 4)
                {
                   if (probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                    {
                        var chance = RandomProvider.Next(0, 10);
                        if (chance < 2)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            var smallBlindsTimes = RandomProvider.Next(2, 6);
                            return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                        }
                    }
                   else if(probability < (double)context.MoneyToCall / (double)context.CurrentPot)
                    {
                        var chance = RandomProvider.Next(0, 10);
                        if (chance < 2)
                        {
                            return PlayerAction.Fold();
                        }
                        else
                        {
                            return PlayerAction.CheckOrCall();
                        }
                    }
                }
                else if (context.MoneyToCall > context.SmallBlind * 4 && context.MoneyToCall < context.SmallBlind * 10)
                {
                    if (probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                    {
                        var chance = RandomProvider.Next(0, 10);
                        if (chance < 4)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            var smallBlindsTimes = RandomProvider.Next(2, 4);
                            return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                        }
                    }
                    else if (probability < (double)context.MoneyToCall / (double)context.CurrentPot)
                    {
                        var chance = RandomProvider.Next(0, 10);
                        if (chance < 3)
                        {
                            return PlayerAction.Fold();
                        }
                        else
                        {
                            return PlayerAction.CheckOrCall();
                        }
                    }
                }
                else if (context.MoneyToCall > context.SmallBlind * 10 && probability > 0.6)
                {
                    return PlayerAction.CheckOrCall();
                }
                else
                {
                    return PlayerAction.Fold();
                }

            }
            #endregion
            #region flop
            else if (context.RoundType == GameRoundType.Flop)
            {
                if (context.MoneyToCall == 0 && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 8)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
                else if (context.MoneyToCall > 0 && context.MoneyToCall < context.CurrentPot && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 3)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else if (chance > 3 && chance < 8)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
                else if (context.MoneyToCall > 0 && context.MoneyToCall < context.CurrentPot && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 3)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else if (chance > 3 && chance < 8)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
            }
            #endregion
            #region turn
            else if (context.RoundType == GameRoundType.Turn)
            {
                if (context.MoneyToCall == 0 && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 8)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
                else if (context.MoneyToCall > 0 && context.MoneyToCall < context.CurrentPot && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 3)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else if (chance > 3 && chance < 8)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
                else if (context.MoneyToCall > 0 && context.MoneyToCall < context.CurrentPot && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 3)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else if (chance > 3 && chance < 8)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
            }
            #endregion
            #region River
            else if (context.RoundType == GameRoundType.River)
            {
                if (context.MoneyToCall == 0 && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 8)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
                else if (context.MoneyToCall > 0 && context.MoneyToCall < context.CurrentPot && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 3)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else if (chance > 3 && chance < 8)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
                else if (context.MoneyToCall > 0 && context.MoneyToCall < context.CurrentPot && probability >= (double)context.MoneyToCall / (double)context.CurrentPot)
                {
                    var chance = RandomProvider.Next(0, 10);
                    if (chance < 3)
                    {
                        double lowBet = context.CurrentPot;
                        var bet = RandomProvider.Next((int)(lowBet / 3), context.CurrentPot);
                        return PlayerAction.Raise(bet);
                    }
                    else if (chance > 3 && chance < 8)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
            }
            #endregion
            return PlayerAction.CheckOrCall();
        }
    }
}