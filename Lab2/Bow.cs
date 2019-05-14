using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Bow : Weapon
    {
        private const int RADIUS = 30;
        private const int DAMAGE = 1;

        public Bow(Game game, Point location): base(game, location)
        {}
        public override string Name
        {
            get
            {
                return "Bow";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, RADIUS, DAMAGE, random);
        }
    }
}
