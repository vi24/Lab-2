using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class BluePotion : Weapon, IPotion
    {
        private const int HEALTH = 5;
        private bool _used;
        public BluePotion(Game game, Point location) : base(game, location)
        {
        }

        public override string Name
        {
            get
            {
                return "Blue Potion";
            }
        }

        public bool Used
        {
            get
            {
                return _used;
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(HEALTH, random);
            _used = true;
        }

        
    }
}
