using System;
using System.Drawing;
using Lab2.GameControls;
using Lab2.Movers.Weapons;


namespace Lab2.Movers.Potions.Impl
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
