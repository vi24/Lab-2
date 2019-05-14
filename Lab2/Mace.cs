using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Mace : Weapon
    {
        private const int RADIUS = 20;
        private const int DAMAGE = 6;

        public Mace(Game game, Point location) : base(game, location)
        {}

        public override string Name
        {
            get
            {
                return "Mace";
            }

        }

        public override void Attack(Direction direction, Random random)
        {
            int i = 0;
            bool enemyHit = false;
            do
            {
                enemyHit = DamageEnemy(direction, RADIUS, DAMAGE, random);
                direction = CounterClockWiseDirection(direction);
                i++;
            } while (i < 4 && !enemyHit);
        }
    }
}
