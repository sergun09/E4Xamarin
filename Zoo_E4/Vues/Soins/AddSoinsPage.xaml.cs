using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo_E4.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zoo_E4.Vues.Soins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSoinsPage : ContentPage
    {
        public DateTime DateSoins { get; set; }

        public Animal CurrentAnimal { get; set; }

        public AddSoinsPage(Animal anim)
        {
            InitializeComponent();
            this.CurrentAnimal = anim;
        }

        private void DatePickerSoins_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateSoins = e.NewDate;
        }

        private void ButtonAddSoins_Clicked(object sender, EventArgs e)
        {
            Zoo_E4.Models.Soins soins = new Models.Soins()
            {
                Datesoins = this.DateSoins,
                Description = this.EditorDescriptif.Text,
                Poids = float.Parse(EntryPoids.Text),
                AnimalId = this.CurrentAnimal.Id,
                VeterinaireId = this.CurrentAnimal.VeterinaireId,
            };
            Zoo_E4.Models.Repository.SoinsRepository.AddSoins(soins);
        }
    }
}