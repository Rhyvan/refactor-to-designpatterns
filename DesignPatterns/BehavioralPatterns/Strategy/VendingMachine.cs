using System;

namespace DesignPatterns.Strategy
{
    public class VendingMachine
    {
        public bool IsWarm { get; private set; }

        public Drink MakeBeverage(Beverage beverage)
        {
            switch (beverage)
            {
                case Beverage.Espresso:
                case Beverage.Latte:
                case Beverage.Macchiato:
                    IsWarm = true;
                    return new Drink("coffee");
                case Beverage.OrangeJuice:
                    IsWarm = false;
                    return new Drink("orange juice");
                default: throw new ArgumentException("no valid beverage selected");
            };
        }
    }
}
