using System;

namespace Common.Models
{
    public class BetTrigger
    {
        public BetType Type { get; private set; }
        public double Amount { get; private set; }

        public BetTrigger(BetType type, double amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}