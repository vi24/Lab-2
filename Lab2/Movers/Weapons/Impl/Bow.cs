using System;
using System.Drawing;
using Lab2.GameControls;

namespace Lab2.Movers.Weapons
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
