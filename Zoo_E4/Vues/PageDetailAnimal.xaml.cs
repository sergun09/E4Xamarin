using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zoo_E4.Models;
using Zoo_E4.Models.Repository;
using Zoo_E4.Vues.Soins;

namespace Zoo_E4.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetailAnimal : ContentPage
    {
        public Animal SelectedAnimal { get; set; }

        public Veterinaire CurrentVeto { get; set; }

        #region UpdateInfosAnimal

        public DateTime NewDateArrivee { get; set; }

        public DateTime NewDateDepart { get; set; }

        public int NewEspece { get; set; }

        public int NewEnclos { get; set; }

        #endregion

        public ObservableCollection<Enclos> ListEnclos
        {
            get { return EnclosRepository.GetAllEnclos(); }
            set { ListEnclos = value; }
        }

        public ObservableCollection<Espece> ListEspeces
        {
            get { return EspeceRepository.GetAllEspeces(); }
            set { ListEspeces = value; }
        }

        public PageDetailAnimal(Animal animal, Veterinaire veto)
        {
            InitializeComponent();
            this.SelectedAnimal = animal;
            this.CurrentVeto = veto;
            this.lblDetail.Text = "Détails de " + this.SelectedAnimal.Nom;
            this.EspecePicker.ItemsSource = ListEspeces;
            this.EnclosPicker.ItemsSource = ListEnclos;

        }

        protected override void OnAppearing()
        {
            LoadData();
        }

        public void LoadData() 
        {
            EntryNomAnimal.Text = this.SelectedAnimal.Nom;
            EntrySexe.Text = this.SelectedAnimal.Sexe;
            DatePickerArrivee.Date = this.SelectedAnimal.DateArrivee;
            DatePickerDepart.Date = this.SelectedAnimal.DateDepart;
            EspecePicker.SelectedIndex = this.SelectedAnimal.EspeceId;
            EnclosPicker.SelectedIndex = this.SelectedAnimal.EnclosId;
        }

        private void ButtonUpdate_Clicked(object sender, EventArgs e)
        {
            this.SelectedAnimal.Nom = this.EntryNomAnimal.Text;
            this.SelectedAnimal.Sexe = this.EntrySexe.Text;
            this.SelectedAnimal.DateArrivee = this.NewDateArrivee;
            this.SelectedAnimal.DateDepart = this.NewDateDepart;
            this.SelectedAnimal.EspeceId = this.NewEspece;
            this.SelectedAnimal.EnclosId = this.NewEnclos;

            AnimalRepository.UpdateAnimal(SelectedAnimal);
            Navigation.PopAsync();
        }

        private void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            AnimalRepository.DeleteAnimal(this.SelectedAnimal.Id);
            DisplayAlert("Supression Animal", this.SelectedAnimal.Nom + " est supprimé", "Ok");
            Navigation.PopAsync();
        }

        private void ButtonListeSoins_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPageSoins(CurrentVeto, SelectedAnimal));
        }

        private void DateDepart_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.NewDateDepart = e.NewDate;
        }

        private void DatePickerArrivee_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.NewDateArrivee = e.NewDate;
        }

        private void EnclosPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NewEnclos = EnclosPicker.SelectedIndex + 1;
        }

        private void EspecePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NewEspece = EspecePicker.SelectedIndex + 1;
        }
    }
}