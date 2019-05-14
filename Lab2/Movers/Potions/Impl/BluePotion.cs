using System;
using System.Drawing;
using Lab2.GameControls;
using Lab2.Movers.Weapons;


namespace Lab2.Movers.Potions.Impl
{
    public class BluePotion : Weapon, IPotion
    {
        private const int HEALTH = 5;
        private bool _used;
        public BluePotion(Game game, Point location) : base(game, location)
        {}

        public override string Name => "Blue Potion";

        public bool Used => _used;

        public override void Attack(Direction direction, Random random)
        {
            _game.IncreasePlayerHealth(HEALTH, random);
            _used = true;
        }

        
    }
}
