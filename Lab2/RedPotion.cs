using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class RedPotion : Weapon, IPotion
    {
        private const int HEALTH = 10;
        private bool _used;
        public RedPotion(Game game, Point location) : base(game, location)
        {
        }

        public bool Used
        {
            get
            {
                return _used;
            }
        }

        public override string Name
        {
            get
            {
                return "Red Potion";
            }

        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(HEALTH, random);
            _used = true;
        }
    }
}
