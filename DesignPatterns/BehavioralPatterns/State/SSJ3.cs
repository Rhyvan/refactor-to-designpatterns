namespace DesignPatterns.State
{
    internal class SSJ3 : Saiyajin
    {
        public SSJ3()
        {
            CurrentLevel = TransformationLevel.SSJ3;
            Hair = "Total Yellow and Long";
            Attack = 500_000_000;
        }

        public override Saiyajin LevelUp() => new BasicSJ();

        public override bool CanDestroyFrieza(Frieza frieza)
        {
            frieza.MakeHimDead();
            return true;
        }

    }
}