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


        public override string Name { get; } = "Ignat_" + Guid.NewGuid();

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            double probability = MonteCarloHelper.GenerateProbabilty(this.FirstCard, this.SecondCard, this.CommunityCards);
            if (!preflopCount.ContainsKey("allin"))
            {
                preflopCount.Add("allin", 0);
            }

            preflopCount["allin"] = preflopCount["allin"] + 1;
            if (preflopCount["allin"] > 3 && probability > 0.5)
            {
                return PlayerAction.CheckOrCall();
            }
            #region Preflop
            if (context.RoundType == GameRoundType.PreFlop)
            {
                if (context.MoneyToCall <= context.SmallBlind * 4)
                {
                    var playHand = HandCheck.PreFlop(this.FirstCard, this.SecondCard);
                    if (playHand == PreflopStrength.Fold)
                    {
                        if (context.CanCheck)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            return PlayerAction.Fold();
                        }
                    }
                    else if (playHand == PreflopStrength.Raise)
                    {
                        var chance = RandomProvider.Next(0, 10);
                        if (chance < 3)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else if (chance >= 3 && chance < 7)
                        {
                            var smallBlindsTimes = RandomProvider.Next(2, 6);
                            return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                        }
                        else if (chance > 7)
                        {
                            var smallBlindsTimes = RandomProvider.Next(3, 8);
                            return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                        }
                    }
                    else if (playHand == PreflopStrength.Call)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
                else if (context.MoneyToCall > context.SmallBlind * 4 && context.MoneyToCall < context.SmallBlind * 10)
                {
                    var playHand = HandCheck.PreFlop(this.FirstCard, this.SecondCard);
                    if (playHand == PreflopStrength.Fold)
                    {
                        if (context.CanCheck)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            return PlayerAction.Fold();
                        }
                    }
                    else if (playHand == PreflopStrength.Raise)
                    {
                        var chance = RandomProvider.Next(0, 10);
                        if (chance < 8)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            var smallBlindsTimes = RandomProvider.Next(2, 3);
                            return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                        }
                    }
                    else if (playHand == PreflopStrength.Call)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else if (context.MoneyToCall > context.SmallBlind * 10)
                    {
                        return PlayerAction.CheckOrCall();
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
                if (probability >= context.MoneyToCall / context.CurrentPot)
                {
                    return PlayerAction.CheckOrCall();
                }
                else
                {
                    return PlayerAction.Fold();
                }                
            }
            #endregion
            #region turn
            else if (context.RoundType == GameRoundType.Turn)
            {
                if (probability >= context.MoneyToCall / context.CurrentPot)
                {
                    return PlayerAction.CheckOrCall();
                }
                else
                {
                    return PlayerAction.Fold();
                }
            }
            #endregion
            #region River
            else if (context.RoundType == GameRoundType.River)
            {
                if (probability >= context.MoneyToCall / context.CurrentPot)
                {
                    return PlayerAction.CheckOrCall();
                }
                else
                {
                    return PlayerAction.Fold();
                }
            }
            #endregion
            return PlayerAction.CheckOrCall();
        }
    }
}