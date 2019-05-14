using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Lab2.Movers.Enemies;
using Lab2.Movers.Weapons;
using Lab2.Movers.Potions.Impl;
using Lab2.Movers.Enemies.Impl;
using Lab2.Movers.Impl;
using Lab2.Movers.Weapons.Impl;

namespace Lab2.GameControls
{
    public class Game
    {
        private Player _player;
        private int _level = 0;
        private Rectangle _boundaries;
        public IEnumerable<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }
        public Point PlayerLocation { get { return _player.Location; } }
        public int PlayerHitPoints { get { return _player.HitPoints; } }
        public IEnumerable<string> PlayerWeapons { get { return _player.Weapons; } }
        
        public int Level { get { return _level; } }
        
        public Rectangle Boundaries { get { return _boundaries; } }

        public Game(Rectangle boundaries)
        {
            this._boundaries = boundaries;
            _player = new Player(this, new Point(boundaries.Left + 10, boundaries.Top + 70));
        }
        public void Move(Direction direction, Random random)
        {
            _player.Move(direction);
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }
        public void Equip(string weaponName)
        {
            _player.Equip(weaponName);
        }
        public bool CheckPlayerInventory(string weaponName)
        {
            return _player.Weapons.Contains(weaponName);
        }
        public void HitPlayer(int maxDamage, Random random)
        {
            _player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            _player.IncreaseHealth(health, random);
        }
        public void Attack(Direction direction, Random random)
        {
            _player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }
        public void NewLevel(Random random)
        {
            _level++;
            switch (_level)
            {
                case 1:
                    Enemies = new List<Enemy>() {
                        new Bat(this, GetRandomLocation(random)),
                    };
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
                case 2:
                    Enemies = new List<Enemy>() {
                        new Ghost(this, GetRandomLocation(random)),
                    };
                    WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    break;
                case 3:
                    Enemies = new List<Enemy>() {
                        new Ghost(this, GetRandomLocation(random)),
                    };
                    WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;
                case 4:
                    Enemies = new List<Enemy>() {
                        new Bat(this, GetRandomLocation(random)),
                        new Ghost(this, GetRandomLocation(random))
                    };
                    if (WeaponInRoom.PickedUp)
                    {
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    }
                    break;
                case 5:
                    Enemies = new List<Enemy>() {
                        new Bat(this, GetRandomLocation(random)),
                        new Ghoul(this, GetRandomLocation(random))
                    };
                    WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    break;
                case 6:
                    Enemies = new List<Enemy>() {
                        new Ghost(this, GetRandomLocation(random)),
                        new Ghoul(this, GetRandomLocation(random))
                    };
                    WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    break;
                case 7:
                    Enemies = new List<Enemy>() {
                        new Bat(this, GetRandomLocation(random)),
                        new Ghost(this, GetRandomLocation(random)),
                        new Ghoul(this, GetRandomLocation(random)),
                    };
                    if (WeaponInRoom.PickedUp)
                    {
                        WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    }
                    break;
                case 8:
                    Console.WriteLine("Finished");
                    Application.Exit();
                    break;
            }
        }
        #region private methods
        private Point GetRandomLocation(Random random)
        {
            return new Point(_boundaries.Left +
            random.Next(_boundaries.Right / 10 - _boundaries.Left / 10) * 10,
            _boundaries.Top +
            random.Next(_boundaries.Bottom / 10 - _boundaries.Top / 10) * 10);
        }
        #endregion
    }
}
