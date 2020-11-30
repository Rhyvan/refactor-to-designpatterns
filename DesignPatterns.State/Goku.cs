using System;
using System.Linq;

namespace DesignPatterns.State
{
    public class Goku
    {
        public TransformationLevel CurrentLevel { get; private set; } = TransformationLevel.FIGHTER;

        public TransformationLevel PowerUp()
        {
            var values = Enum.GetValues(typeof(TransformationLevel));
            var levelIndex = Enumerable.Range(0, values.Length)
                .Where(i => CurrentLevel.Equals(values.GetValue(i)))
                .DefaultIfEmpty(-1)
                .FirstOrDefault();

            var index = (levelIndex + 1) % values.Length;
            CurrentLevel = (TransformationLevel)index;
            return CurrentLevel;
        }

        public string HairColor()
        {
            var color = CurrentLevel switch
            {
                TransformationLevel.FIGHTER => "Black",
                TransformationLevel.SSJ1 => "Yellow",
                TransformationLevel.SSJ2 => "Even More Yellow",
                TransformationLevel.SSJ3 => "Total Yellow and Long",
                _ => throw new NotImplementedException()
            };

            return color;
        }

        public int AttackValue()
        {
            return CurrentLevel switch
            {
                TransformationLevel.FIGHTER => 9000,
                TransformationLevel.SSJ1 => 100_000,
                TransformationLevel.SSJ2 => 100_000_000,
                TransformationLevel.SSJ3 => 500_000_000,
            };
        }

        public bool TryToDestroyFrieza(Frieza frieza)
        {
            if (CurrentLevel == TransformationLevel.FIGHTER)
            {
                return false;
            }
            else
            {
                frieza.MakeHimDead();
                return true;
            }
        }


    }
}
