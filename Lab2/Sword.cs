using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Lab2
{
    class Sword : Weapon
    {
        private const int RADIUS = 20;
        private const int DAMAGE = 3;

        public Sword(Game game, Point location): base(game, location)
        {}

        public override string Name
        {
            get
            {
                return "Sword";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            if (!DamageEnemy(direction, RADIUS, DAMAGE, random))
            {
                if (!DamageEnemy(ClockWiseDirection(direction), RADIUS, DAMAGE, random))
                {
                    DamageEnemy(CounterClockWiseDirection(direction), RADIUS, DAMAGE, random);
                }
            }
        }
    }
}
