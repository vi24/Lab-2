using System;
using System.Drawing;
using System.Windows.Forms;
using Lab2.GameControls;
using Lab2.Movers.Enemies;
using Lab2.Movers.Enemies.Impl;

namespace Lab2
{
    public partial class TheQuestForm : Form
    {
        enum InventoryType
        {
            Weapon, Potion
        }
        private Game _game;
        private Random _random = new Random();
        public TheQuestForm()
        {
            InitializeComponent();
        }


        public void UpdateCharacters()
        {
            
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            UpdatePlayer();

            foreach (Enemy enemy in _game.Enemies)
            {
                if (enemy is Bat)
                {
                    BatPicBox.Location = enemy.Location;
                    BatHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghost)
                {
                    GhostPicBox.Location = enemy.Location;
                    GhostHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghoul)
                {
                    GhoulPicBox.Location = enemy.Location;
                    GhoulHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }

            SetEnemyVisibility(showBat, showGhost, showGhoul);

            SetVisiblityPicBoxes();

            Control weaponControl = SetControlVisiblityPicBoxes();

            SetVisibilityInventoryIcons();

            SetVisiblityPickeUp(weaponControl);

            ShowGamoOverMessageBox(enemiesShown);
        }


        #region private methods
        private void TheQuestForm_Load(object sender, EventArgs e)
        {
            _game = new Game(new Rectangle(100, 57, 780, 300));
            _game.NewLevel(_random);
            UpdateCharacters();
        }

        private void SwordInventoryPicBox_Click(object sender, EventArgs e)
        {
            if (_game.CheckPlayerInventory("Sword"))
            {
                _game.Equip("Sword");
                UpdateAttackButtons(InventoryType.Weapon);
                RemovePicBoxBorders();
                SwordInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void BowInventoryPicBox_Click(object sender, EventArgs e)
        {
            if (_game.CheckPlayerInventory("Bow"))
            {
                _game.Equip("Bow");
                UpdateAttackButtons(InventoryType.Weapon);
                RemovePicBoxBorders();
                BowInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void MaceInventoryPicBox_Click(object sender, EventArgs e)
        {
            if (_game.CheckPlayerInventory("Mace"))
            {
                _game.Equip("Mace");
                UpdateAttackButtons(InventoryType.Weapon);
                RemovePicBoxBorders();
                MaceInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void PotionBlueInventoryPicBox_Click(object sender, EventArgs e)
        {
            _game.Equip("Blue Potion");
            UpdateAttackButtons(InventoryType.Potion);
            RemovePicBoxBorders();
            PotionBlueInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void PotionRedInventoryPicBox_Click(object sender, EventArgs e)
        {
            _game.Equip("Red Potion");
            UpdateAttackButtons(InventoryType.Potion);
            RemovePicBoxBorders();
            PotionRedInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;

        }
        private void UpMoveButton_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.Up, _random);
            UpdateCharacters();
        }

        private void DownMoveButton_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.Down, _random);
            UpdateCharacters();
        }

        private void LeftMoveButton_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.Left, _random);
            UpdateCharacters();
        }

        private void RightMoveButton_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.Right, _random);
            UpdateCharacters();
        }

        private void UpAttackButton_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.Up, _random);
            UpdateCharacters();
        }

        private void DownAttackButton_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.Down, _random);
            UpdateCharacters();
        }

        private void LeftAttackButton_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.Left, _random);
            UpdateCharacters();
        }

        private void RightAttackButton_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.Right, _random);
            UpdateCharacters();
        }

        private void RemovePicBoxBorders()
        {
            SwordInventoryPicBox.BorderStyle = BorderStyle.None;
            BowInventoryPicBox.BorderStyle = BorderStyle.None;
            MaceInventoryPicBox.BorderStyle = BorderStyle.None;
            PotionRedInventoryPicBox.BorderStyle = BorderStyle.None;
            PotionBlueInventoryPicBox.BorderStyle = BorderStyle.None;
        }

        private void UpdateAttackButtons(InventoryType inventory)
        {
            switch (inventory)
            {
                case InventoryType.Weapon:
                    UpAttackButton.Text = "↑";
                    DownAttackButton.Visible = true;
                    LeftAttackButton.Visible = true;
                    RightAttackButton.Visible = true;
                    break;
                case InventoryType.Potion:
                    UpAttackButton.Text = "Drink!";
                    DownAttackButton.Visible = false;
                    LeftAttackButton.Visible = false;
                    RightAttackButton.Visible = false;
                    break;
            }
        }

        private void SetVisibilityInventoryIcons()
        {
            SwordInventoryPicBox.Visible = _game.CheckPlayerInventory("Sword");
            BowInventoryPicBox.Visible = _game.CheckPlayerInventory("Bow");
            MaceInventoryPicBox.Visible = _game.CheckPlayerInventory("Mace");
            PotionBlueInventoryPicBox.Visible = _game.CheckPlayerInventory("Blue Potion");
            PotionRedInventoryPicBox.Visible = _game.CheckPlayerInventory("Red Potion");
        }

        private Control SetControlVisiblityPicBoxes()
        {
            Control weaponControl = null;
            switch (_game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = SwordPicBox;
                    break;
                case "Bow":
                    weaponControl = BowPicBox;
                    break;
                case "Mace":
                    weaponControl = MacePicBox;
                    break;
                case "Red Potion":
                    weaponControl = PotionRedPicBox;
                    break;
                case "Blue Potion":
                    weaponControl = PotionBluePicBox;
                    break;
            }
            weaponControl.Visible = true;
            return weaponControl;
        }

        private void SetVisiblityPicBoxes()
        {
            SwordPicBox.Visible = false;
            BowPicBox.Visible = false;
            PotionRedPicBox.Visible = false;
            PotionBluePicBox.Visible = false;
            MacePicBox.Visible = false;
        }

        private void SetEnemyVisibility(bool showBat, bool showGhost, bool showGhoul)
        {
            if (!showBat)
            {
                BatPicBox.Visible = false;
                BatHitPointsLabel.Text = "";
            }
            else
            {
                BatPicBox.Visible = true;
            }

            if (!showGhost)
            {
                GhostPicBox.Visible = false;
                GhostHitPointsLabel.Text = "";
            }
            else
            {
                GhostPicBox.Visible = true;
            }
            if (!showGhoul)
            {
                GhoulPicBox.Visible = false;
                GhoulHitPointsLabel.Text = "";
            }
            else
            {
                GhoulPicBox.Visible = true;
            }

        }

        private void ShowGamoOverMessageBox(int enemiesShown)
        {
            if (_game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                _game.NewLevel(_random);
                UpdateCharacters();
            }
        }

        private void SetVisiblityPickeUp(Control weaponControl)
        {
            weaponControl.Location = _game.WeaponInRoom.Location;
            if (_game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;
        }

        private void UpdatePlayer()
        {
            PlayerPicBox.Location = _game.PlayerLocation;
            PlayerHitPointsLabel.Text =
            _game.PlayerHitPoints.ToString();
        }
        #endregion



    }
}
