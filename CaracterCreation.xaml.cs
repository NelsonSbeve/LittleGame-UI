using Microsoft.Maui.Controls;

namespace LittleGameUI
{
    public partial class CaracterCreation : ContentPage
    {

        private Caracter Hero;

        public CaracterCreation()
        {
            InitializeComponent();
            _ = InitializeAsync();
        }

        async Task InitializeAsync()
        {
            Hero = await CreateHeroAsync();
        }
        async Task<Caracter> CreateHeroAsync()
        {
            string name = string.Empty;
            
                    

            // Use .NET MAUI's input dialog to get user input
            Entry nameInput = new Entry { Placeholder = "Enter Name" };
            nameInput.Completed += OnEntryCompleted;



            

            name = nameInput.Text;
            
            return new Caracter(name);
            
        }
        async Task DisplayDialogAsync()
        {
            // You may need to implement your own dialog display logic.
            // For simplicity, we'll use DisplayAlert as an example.
            await DisplayAlert("Congrats", $"{Hero.name}", "Welcome to BattleMania");
            await Navigation.PushAsync(new GamePage());
            
        }



        async void OnEntryCompleted(object sender, EventArgs e)
        {

            Hero.name = ((Entry)sender).Text;
            await DisplayDialogAsync();
            
        }

    }
}