using System;
using System.Dynamic;

namespace Common.Models
{
    public class Campaign
    {
        public string Title { get; private set; }
        public BetQuantifierType Quantifier { get; private set; }
        public BetTrigger BetTrigger { get; private set; }

        public Campaign(string title, BetQuantifierType quantifier, BetTrigger betTrigger)
        {
            Title = title;
            Quantifier = quantifier;
            BetTrigger = betTrigger;
        }
    }
}