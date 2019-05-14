using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab2
{
    class Bat : Enemy
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
                        location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                        break;
                    case 2:
                        location = Move((Direction)random.Next(3), game.Boundaries);
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
