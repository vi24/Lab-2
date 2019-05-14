using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class TheQuestForm : Form
    {
        enum InventoryType
        {
            Weapon, Potion
        }
        private Game game;
        private Random random = new Random();
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

            foreach (Enemy enemy in game.Enemies)
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
            game = new Game(new Rectangle(100, 57, 780, 300));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void SwordInventoryPicBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                UpdateAttackButtons(InventoryType.Weapon);
                RemovePicBoxBorders();
                SwordInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void BowInventoryPicBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                UpdateAttackButtons(InventoryType.Weapon);
                RemovePicBoxBorders();
                BowInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void MaceInventoryPicBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                UpdateAttackButtons(InventoryType.Weapon);
                RemovePicBoxBorders();
                MaceInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void PotionBlueInventoryPicBox_Click(object sender, EventArgs e)
        {
            game.Equip("Blue Potion");
            UpdateAttackButtons(InventoryType.Potion);
            RemovePicBoxBorders();
            PotionBlueInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void PotionRedInventoryPicBox_Click(object sender, EventArgs e)
        {
            game.Equip("Red Potion");
            UpdateAttackButtons(InventoryType.Potion);
            RemovePicBoxBorders();
            PotionRedInventoryPicBox.BorderStyle = BorderStyle.FixedSingle;

        }
        private void UpMoveButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void DownMoveButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void LeftMoveButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void RightMoveButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void UpAttackButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void DownAttackButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void LeftAttackButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void RightAttackButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
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
        #endregion

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
            SwordInventoryPicBox.Visible = game.CheckPlayerInventory("Sword");
            BowInventoryPicBox.Visible = game.CheckPlayerInventory("Bow");
            MaceInventoryPicBox.Visible = game.CheckPlayerInventory("Mace");
            PotionBlueInventoryPicBox.Visible = game.CheckPlayerInventory("Blue Potion");
            PotionRedInventoryPicBox.Visible = game.CheckPlayerInventory("Red Potion");
        }

        private Control SetControlVisiblityPicBoxes()
        {
            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
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
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void SetVisiblityPickeUp(Control weaponControl)
        {
            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;
        }

        private void UpdatePlayer()
        {
            PlayerPicBox.Location = game.PlayerLocation;
            PlayerHitPointsLabel.Text =
            game.PlayerHitPoints.ToString();
        }

    }
}
