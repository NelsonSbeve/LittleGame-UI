using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace LittleGameUI
{
    public partial class GamePage : ContentPage
    {
        private List<Caracter> Opponents;
        

        public GamePage()
        {
            InitializeComponent();
            InitializeGame();
        }

        

        private void InitializeGame()
        {
             
            
            Opponents = CreateOpponents();
            
            
            
           
        }
         private void UpdateStatusLabel(string message)
        {
            StatusLabel.Text = message;
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

      
        private async void OnStartBattleClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new CaracterCreation());
        }
    }
}
