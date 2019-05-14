using System;
using System.Drawing;
using Lab2.Movers.Enemies;
using Lab2.GameControls;

namespace Lab2
{
    public class Ghost : Enemy
    {
        private const int HIT_POINTS = 8;
        private const int MAX_DAMAGE = 3;

        public Ghost (Game game, Point location): base(game, location, HIT_POINTS)
        {}

        public override void Move(Random random)
        {
            if(HitPoints > 0)
            {
                int rand = random.Next(1, 4);

                switch (rand)
                {
                    case 1:
                        _location = Move(FindPlayerDirection(_game.PlayerLocation), _game.Boundaries);
                        break;
                    case 2:
                        break;
                    case 3:
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
