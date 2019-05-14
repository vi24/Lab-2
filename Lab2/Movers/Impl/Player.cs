using System;
using System.Collections.Generic;
using System.Drawing;
using Lab2.GameControls;
using Lab2.Movers.Weapons;

namespace Lab2.Movers.Impl
{
    public class Player : Mover
    {
        private Weapon _equippedWeapon;
        private List<Weapon> _inventory = new List<Weapon>();
        public int HitPoints { get; private set; }
        
        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in _inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }
        public Player(Game game, Point location): base(game, location)
        {
            HitPoints = 10;
        }
        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }
        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }
        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in _inventory)
            {
                if (weapon.Name == weaponName)
                {
                    _equippedWeapon = weapon;
                }   
            }
        }

        public void Move(Direction direction)
        {
            base._location = Move(direction, _game.Boundaries);
            if (!_game.WeaponInRoom.PickedUp) { return; }
            if (_game.WeaponInRoom.Nearby(_game.WeaponInRoom.Location, base._location, 1))
            {
                _game.WeaponInRoom.PickUpWeapon();
                this._inventory.Add(_game.WeaponInRoom);
                if(_equippedWeapon is null)
                {
                    this.Equip(_game.WeaponInRoom.Name);
                }
            }
        }

        public void Attack(Direction direction, Random random)
        {
            _equippedWeapon?.Attack(direction, random);
        }
    }
}
