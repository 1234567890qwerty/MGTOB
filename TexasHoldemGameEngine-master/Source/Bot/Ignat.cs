﻿using System;
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
            if (!preflopCount.ContainsKey("allin"))
            {
                preflopCount.Add("allin", 0);
            }

            preflopCount["allin"] = preflopCount["allin"] + 1;
            if (preflopCount["allin"] > 3)
            {

            }

            if (context.RoundType == GameRoundType.PreFlop)
            {
                if (context.MoneyToCall < context.SmallBlind * 4)
                {
                    var playHand = HandCheck.PreFlop(this.FirstCard, this.SecondCard);
                    if (playHand == PreflopStrength.Unplayable)
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
                    else if (playHand == PreflopStrength.Recommended)
                    {
                        var smallBlindsTimes = RandomProvider.Next(4, 12);
                        return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                    }
                    else if (playHand == PreflopStrength.Risky)
                    {
                        var chance = RandomProvider.Next(1, 10);
                        if (chance < 6)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            var smallBlindsTimes = RandomProvider.Next(4, 8);
                            return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                        }
                    }
                    else if (playHand == PreflopStrength.NotRecommended)
                    {
                        var chance = RandomProvider.Next(1, 10);
                        if (chance < 8)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            var smallBlindsTimes = RandomProvider.Next(4, 5);
                            return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                        }
                    }
                }
                else if (context.MoneyToCall > context.SmallBlind * 4 && context.MoneyToCall < context.SmallBlind * 10)
                {
                    var playHand = HandCheck.PreFlop(this.FirstCard, this.SecondCard);
                    if (playHand == PreflopStrength.Unplayable)
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
                    else if (playHand == PreflopStrength.Recommended)
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
                    else if (playHand == PreflopStrength.Risky)
                    {

                        var chance = RandomProvider.Next(0, 10);
                        if (chance < 8)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            return PlayerAction.Fold();
                        }
                    }
                    else if (playHand == PreflopStrength.NotRecommended)
                    {
                        var chance = RandomProvider.Next(1, 10);
                        if (chance < 8)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            var smallBlindsTimes = RandomProvider.Next(4, 5);
                            return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
                        }
                    }

                    else if (context.MoneyToCall > context.SmallBlind * 10)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                }
                else if (context.RoundType == GameRoundType.Flop)
                {
                    return PlayerAction.CheckOrCall();
                }
                else if (context.RoundType == GameRoundType.Turn)
                {
                    return PlayerAction.CheckOrCall();
                }
                else if (context.RoundType == GameRoundType.River)
                {
                    return PlayerAction.CheckOrCall();
                }

                return PlayerAction.CheckOrCall();
            }
        }
    }