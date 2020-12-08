using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State
{
    public class Frieza
    {
        private bool _alive = true;

        public void MakeHimDead()
        {
            _alive = false;
        }

        public bool IsAlive()
        {
            return _alive;
        }
    }
}
