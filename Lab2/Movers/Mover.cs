using System;
using System.Drawing;
using Lab2.GameControls;

namespace Lab2.Movers
{
    public abstract class Mover
    {
        private const int MOVE_INTERVAL = 10;
        protected Point _location;
        protected Game _game;

        public Point Location { get { return _location; } }

        public Mover(Game game, Point location)
        {
            this._game = game;
            this._location = location;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            if (Math.Abs(_location.X - locationToCheck.X) < distance &&
            (Math.Abs(_location.Y - locationToCheck.Y) < distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Point Move(Direction direction, Rectangle boundaries)
        {
            Point newLocation = _location;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MOVE_INTERVAL >= boundaries.Top)
                        newLocation.Y -= MOVE_INTERVAL;
                    break;
                case Direction.Down:
                    if (newLocation.Y + MOVE_INTERVAL <= boundaries.Bottom)
                        newLocation.Y += MOVE_INTERVAL;
                    break;
                case Direction.Left:
                    if (newLocation.X - MOVE_INTERVAL >= boundaries.Left)
                        newLocation.X -= MOVE_INTERVAL;
                    break;
                case Direction.Right:
                    if (newLocation.X + MOVE_INTERVAL <= boundaries.Right)
                        newLocation.X += MOVE_INTERVAL;
                    break;
                default: break;
            }
            return newLocation;
        }
    }
}
