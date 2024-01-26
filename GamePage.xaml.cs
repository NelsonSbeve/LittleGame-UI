using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LittleGameUI
{
    public partial class GamePage : ContentPage
    {
        private Caracter Hero;
        private List<Caracter> Opponents;
        private int currentOpponentIndex;
        private Battle currentBattle;

        public GamePage()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            Hero = CreateHero();
            Opponents = CreateOpponents();
            currentOpponentIndex = 0;

            UpdateStatusLabel($"Caracter successfully created. Welcome {Hero.name}");
        }

        private Caracter CreateHero()
        {
            string name;
            string gender;

            // Simulate user input (replace this with actual user input in a real app)
            name = "Player";
            gender = "Male";

            return new Caracter(name, gender);
        }

        private List<Caracter> CreateOpponents()
        {
            var opponents = new List<Caracter>();

            for (int i = 0; i < 4; i++)
            {
                var opponentName = $"Opponent {i + 1}";
                var opponentGender = "Male";
                var opponentHealth = 100;
                var opponent = new Caracter(opponentName, opponentGender, opponentHealth);
                opponents.Add(opponent);
            }

            return opponents;
        }

        private void UpdateStatusLabel(string message)
        {
            StatusLabel.Text = message;
        }

        private async void OnStartBattleClicked(object sender, EventArgs e)
        {
            if (currentOpponentIndex < Opponents.Count)
            {
                var opponent = Opponents[currentOpponentIndex];
                currentBattle = new Battle(Hero, opponent);

                UpdateStatusLabel($"Starting battle against {opponent.name}");

                await Task.Run(() => currentBattle.Start());

                currentOpponentIndex++;

                if (currentOpponentIndex < Opponents.Count)
                {
                    UpdateStatusLabel("Press 'Start Battle' for the next battle");
                }
                else
                {
                    UpdateStatusLabel("All battles completed. Game Over!");
                }
            }
        }
    }
}
