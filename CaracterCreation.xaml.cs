using Microsoft.Maui.Controls;

namespace LittleGameUI
{
    public partial class CaracterCreation : ContentPage
    {

        private Caracter Hero;
        public CaracterCreation()
        {
            InitializeComponent();
            Hero = CreateHero();
            
            
        }
        Caracter CreateHero()
        {
                string name = string.Empty;
                string gender = string.Empty;
                    

                    // Use .NET MAUI's input dialog to get user input
                    Entry nameInput = new Entry { Placeholder = "Enter Name" };
                    nameInput.Completed += (s, e) => OnEntryCompleted(nameInput, ref name);

                    Entry genderInput = new Entry { Placeholder = "Enter Gender" };
                    genderInput.Completed += (s, e) => OnEntryCompleted(genderInput, ref gender);

                    
                    async void CreateOnClick(object sender, EventArgs e)
                    {
                        name = NameEntry.Text;
                        gender = GenderEntry.Text;
                        

                        StatusLabel.Text = $"Character created!\nName: {name}\nGender: {gender}";
                        await Navigation.PushAsync(new BattleScreen());

                    } 
                    return new Caracter(name, gender);

                    

                    


                    

                    void OnEntryCompleted(Entry entry, ref string value)
                    {
                        value = entry.Text;
                
                    }  
        }




        




        

            
        
    }
}