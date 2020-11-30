namespace DesignPatterns.State
{
    internal class SSJ1 : Saiyajin
    {
        public SSJ1()
        {
            CurrentLevel = TransformationLevel.SSJ1;
            Hair = "Yellow";
            Attack = 100_000;
        }

        public override Saiyajin LevelUp() => new SSJ2();


        public override bool CanDestroyFrieza(Frieza frieza)
        {
            frieza.MakeHimDead();
            return true;
        }
    }
}