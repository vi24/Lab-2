using System;
using System.Collections.Generic;
using System.Drawing;
using Lab2.GameControls;
using Lab2.Movers;
using Lab2.Movers.Weapons;

namespace Lab2
{
    class Player : Mover
    {
        private Weapon equippedWeapon;
        public int HitPoints { get; private set; }
        private List<Weapon> inventory = new List<Weapon>();
        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }
        public Player(Game game, Point location)
        : base(game, location)
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
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
            }
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                if (game.WeaponInRoom.Nearby(game.WeaponInRoom.Location, this.Location, 1))
                {
                    game.WeaponInRoom.PickUpWeapon();
                    this.inventory.Add(game.WeaponInRoom);
                    if(equippedWeapon is null)
                    {
                        this.Equip(game.WeaponInRoom.Name);
                    }
                }
            }
        }

        public void Attack(Direction direction, Random random)
        {
            equippedWeapon?.Attack(direction, random);
        }
    }
}
