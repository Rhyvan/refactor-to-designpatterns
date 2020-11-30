using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.State
{
    class BasicSJ : Saiyajin
    {
        public BasicSJ()
        {
            CurrentLevel = TransformationLevel.FIGHTER;
            Hair = "Black";
            Attack = 9000;
        }
        public override Saiyajin LevelUp() => new SSJ1();

        public override bool CanDestroyFrieza(Frieza frieza) => false;



    }
}
