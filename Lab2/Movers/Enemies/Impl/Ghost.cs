using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab2.Movers.Enemies;
using Lab2.GameControls;

namespace Lab2
{
    class Ghost : Enemy
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
                        location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                if (NearPlayer())
                {
                    game.HitPlayer(MAX_DAMAGE, random);
                }
            }
        }
    }
}
