using System;
using System.Drawing;
using Lab2.GameControls;

namespace Lab2.Movers.Weapons.Impl
{
    public class Bow : Weapon
    {
        private const int RADIUS = 30;
        private const int DAMAGE = 1;

        public Bow(Game game, Point location): base(game, location)
        {}
        public override string Name => "Bow";

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, RADIUS, DAMAGE, random);
        }
    }
}
