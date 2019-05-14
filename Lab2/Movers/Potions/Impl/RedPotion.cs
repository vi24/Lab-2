using System;
using System.Drawing;
using Lab2.GameControls;
using Lab2.Movers.Weapons;

namespace Lab2.Movers.Potions.Impl
{
    public class RedPotion : Weapon, IPotion
    {
        private const int HEALTH = 10;
        private bool _used;
        public RedPotion(Game game, Point location) : base(game, location)
        {}

        public bool Used => _used;

        public override string Name => "Red Potion";

        public override void Attack(Direction direction, Random random)
        {
            _game.IncreasePlayerHealth(HEALTH, random);
            _used = true;
        }
    }
}
