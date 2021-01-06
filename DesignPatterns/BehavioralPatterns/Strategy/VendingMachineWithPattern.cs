using System;

namespace DesignPatterns.Strategy
{
    public class VendingMachineWithPattern
    {
        IConcoct strategy;
        public bool IsWarm { get; private set; }

        public Drink MakeBeverage(Beverage beverage)
        {
            strategy = StrategySetter.CreateStrategy(beverage);

            IsWarm = strategy.HeatUpMachine();
            return strategy.ConcoctBeverage();
        }
    }

    public static class StrategySetter
    {
        public static IConcoct CreateStrategy(Beverage beverage)
        {
            switch (beverage)
            {
                case Beverage.Espresso:
                case Beverage.Latte:
                case Beverage.Macchiato:
                    return new ConcoctCoffee();
                case Beverage.OrangeJuice:
                    return new ConcoctJuice();
                default: throw new ArgumentException("no valid beverage selected");
            };
        }
    }


    public interface IConcoct
    {
        Drink ConcoctBeverage();
        bool HeatUpMachine();
    }

    public class ConcoctCoffee : IConcoct
    {
        public Drink ConcoctBeverage() => new Drink("coffee");

        public bool HeatUpMachine() => true;
        
    }

    public class ConcoctJuice : IConcoct
    {
        public Drink ConcoctBeverage() => new Drink("orange juice");

        public bool HeatUpMachine() => false;
    }
}
