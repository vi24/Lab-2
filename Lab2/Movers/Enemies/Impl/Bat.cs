using System;
using System.Drawing;
using Lab2.GameControls;

namespace Lab2.Movers.Enemies.Impl
{
    public class Bat : Enemy
    {
        private const int HIT_POINTS = 6;
        private const int MAX_DAMAGE = 2;

        public Bat(Game game, Point location): base(game, location, HIT_POINTS)
        {}
        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                int rand = random.Next(1, 3);
                switch (rand)
                {
                    case 1:
                        _location = Move(FindPlayerDirection(_game.PlayerLocation), _game.Boundaries);
                        break;
                    case 2:
                        _location = Move((Direction)random.Next(3), _game.Boundaries);
                        break;
                }
                if (NearPlayer())
                {
                    _game.HitPlayer(MAX_DAMAGE, random);
                }
            }
        }
    }
}
