using System;
using System.Linq;

namespace DesignPatterns.State
{
    public class Goku
    {
        protected Saiyajin _context;


        public TransformationLevel CurrentLevel
        { 
            get => _context.CurrentLevel;
        }

        public Goku()
        {
            _context = new BasicSJ();
        }

        public bool TryToDestroyFrieza(Frieza frieza) => _context.CanDestroyFrieza(frieza);
        
        public string HairColor() => _context.Hair;

        public int AttackValue() => _context.Attack;

        public void PowerUp()
        { 
            _context = _context.LevelUp(); 
        }
    }
}
