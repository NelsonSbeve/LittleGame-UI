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
        private Caracter Hero;
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
            Hero = CreateHero();
            Caracter CreateHero()
            {
                    
                        string name;
                        string gender;

                        // Use .NET MAUI's input dialog to get user input
                        Entry nameInput = new Entry { Placeholder = "Enter Name" };
                        nameInput.TextChanged += OnEntryTextChanged;
                        Entry genderInput = new Entry { Placeholder = "Enter Gender" };
                        

                    name = nameInput.Text;
                    gender = genderInput.Text;

                    


                    return new Caracter(name, gender);
            }

            void OnEntryTextChanged(object sender, TextChangedEventArgs e)
            {
                string oldText = e.OldTextValue;
                string newText = e.NewTextValue;
                
            }  
        }
    }
}
