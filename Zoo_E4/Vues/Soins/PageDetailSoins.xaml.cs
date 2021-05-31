using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zoo_E4.Vues.Soins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetailSoins : ContentPage
    {
        public Zoo_E4.Models.Soins SelectedSoins { get; set; }

        public DateTime NewDate { get; set; }

        public PageDetailSoins(Zoo_E4.Models.Soins soins)
        {
            InitializeComponent();
            this.SelectedSoins = soins;
            LoadDataSoins();   
        }

        public void LoadDataSoins() 
        {
            this.lblSoins.Text = "Soins du " + this.SelectedSoins.Datesoins;
            this.EditorDescriptif.Text = this.SelectedSoins.Description;
            this.EntryPoids.Text = this.SelectedSoins.Poids.ToString();
            this.DatePickerSoins.Date = this.SelectedSoins.Datesoins;
        }

        private void ButtonDeleteSoins_Clicked(object sender, EventArgs e)
        {
            Zoo_E4.Models.Repository.SoinsRepository.DeleteSoins(this.SelectedSoins.Id);
            DisplayAlert("Supression Animal", "Supprimer le soins du " + this.SelectedSoins.Datesoins + " est supprimé", "Ok");
            Navigation.PopAsync();
        }

        private void ButtonUpdateSoins_Clicked(object sender, EventArgs e)
        {
            this.SelectedSoins.Datesoins = this.NewDate;
            this.SelectedSoins.Description = this.EditorDescriptif.Text;
            this.SelectedSoins.Poids = float.Parse(this.EntryPoids.Text);
            Zoo_E4.Models.Repository.SoinsRepository.UpdateSoins(this.SelectedSoins);
            Navigation.PopAsync();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.NewDate = e.NewDate;
        }
    }
}