using System;
using System.Drawing;
using Lab2.GameControls;

namespace Lab2.Movers.Weapons.Impl
{
    public class Mace : Weapon
    {
        private const int RADIUS = 20;
        private const int DAMAGE = 6;

        public Mace(Game game, Point location) : base(game, location)
        {}

        public override string Name => "Mace";

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
