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
                // if (!preflopCount.ContainsKey("allin"))
                // {
                //     preflopCount.Add("allin", 0);
                // }
                // 
                // if (!preflopCount.ContainsKey("raise"))
                // {
                //     preflopCount.Add("raise", 0);
                // }
                // 
                // if (!preflopCount.ContainsKey("check"))
                // {
                //     preflopCount.Add("check", 0);
                // }
                // 
                // if (context.IsAllIn)
                // {
                //     preflopCount["allin"] = preflopCount["allin"] + 1;
                // }
                // 
                // if (preflopCount["allin"] > 3 && probability > 0.65)
                // {
                //     return PlayerAction.Raise(context.CurrentMaxBet);
                // }
                // 
                // if (context.RoundType == GameRoundType.PreFlop && context.MoneyToCall > 0)
                // {
                //     preflopCount["raise"] += 1;
                // }
                // 
                // if (context.RoundType == GameRoundType.PreFlop && context.MoneyToCall == 0)
                // {
                //     preflopCount["call"] += 1;
                // }

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
                // if (!flopCount.ContainsKey("allin"))
                // {
                //     flopCount.Add("allin", 0);
                // }
                // 
                // if (!flopCount.ContainsKey("raise"))
                // {
                //     flopCount.Add("raise", 0);
                // }
                // 
                // if (context.MoneyToCall > 0)
                // {
                //     flopCount["raise"] += 1;
                // }

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
                    else
                    {
                        return PlayerAction.Fold();
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
                else
                {
                    return PlayerAction.Fold();
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