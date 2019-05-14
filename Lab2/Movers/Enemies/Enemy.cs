using System;
using System.Drawing;
using Lab2.GameControls;

namespace Lab2.Movers.Enemies
{
    public abstract class Enemy : Mover
    {
        private const int NEAR_PLAYER_DISTANCE = 25;
        public int HitPoints { get; private set; }
        public bool Dead
        {
            get
            {
                return (HitPoints <= 0) ? true : false;
            }
        }
        public Enemy(Game game, Point location, int hitPoints): base(game, location)
        {
            HitPoints = hitPoints;
        }
        public abstract void Move(Random random);
        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }
        protected bool NearPlayer()
        {
            return (Nearby(_game.PlayerLocation, NEAR_PLAYER_DISTANCE));
        }
        protected Direction FindPlayerDirection(Point playerLocation)
        {
            Direction directionToMove;
            if (playerLocation.X > _location.X + 10)
                directionToMove = Direction.Right;
            else if (playerLocation.X < _location.X - 10)
                directionToMove = Direction.Left;
            else if (playerLocation.Y < _location.Y - 10)
                directionToMove = Direction.Up;
            else
                directionToMove = Direction.Down;
            return directionToMove;
        }
    }
}
