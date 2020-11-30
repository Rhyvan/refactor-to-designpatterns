namespace DesignPatterns.State
{
    internal class SSJ2 : Saiyajin
    {
        public SSJ2()
        {
            CurrentLevel = TransformationLevel.SSJ2;
            Hair = "Even More Yellow";
            Attack = 100_000_000;
        }
        public override Saiyajin LevelUp() => new SSJ3();

        public override bool CanDestroyFrieza(Frieza frieza)
        {
            frieza.MakeHimDead();
            return true;
        }
    }
}