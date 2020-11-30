using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State
{
    public abstract class Saiyajin
    {
         public TransformationLevel CurrentLevel { get; protected set; }
        public string Hair { get; protected set; }
        public int Attack { get; protected set; }


        public abstract Saiyajin LevelUp();

        public abstract bool CanDestroyFrieza(Frieza frieza);
    }
}
