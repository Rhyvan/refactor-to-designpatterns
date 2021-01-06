namespace DesignPatterns.Strategy
{
    public class Drink
    {
        public string Name { get; private set; }
        public Drink(string name)
        {
            Name = name;
        }
    }
}
