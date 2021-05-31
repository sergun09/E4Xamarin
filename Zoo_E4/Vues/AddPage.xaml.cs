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

namespace Zoo_E4.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        private ObservableCollection<Enclos> _ListEnclos;

        public ObservableCollection<Enclos> ListEnclos
        {
            get { return _ListEnclos ?? (EnclosRepository.GetAllEnclos()); }
            set { _ListEnclos = value; }
        }

        private ObservableCollection<Espece> _ListEspeces;

        public ObservableCollection<Espece> ListEspeces
        {
            get { return _ListEspeces ?? (EspeceRepository.GetAllEspeces()); }
            set { _ListEspeces = value; }
        }

        public DateTime DateArrivee { get; set; }

        public DateTime DateDepart { get; set; }

        public Veterinaire veto { get; set; }

        public int SelectedIdEspece { get; set; }

        public int SelectedIdEnclos { get; set; }

        public AddPage(Veterinaire veto)
        {
            InitializeComponent();
            this.veto = veto;
            EnclosPicker.ItemsSource = ListEnclos;
            EspecePicker.ItemsSource = ListEspeces;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Animal anim = new Animal()
            {
                EnclosId = this.SelectedIdEnclos,
                VeterinaireId = this.veto.Id,
                EspeceId = this.SelectedIdEspece,
                Nom = EntryNomAnimal.Text,
                DateArrivee = this.DateArrivee,
                DateDepart = this.DateDepart,
                Sexe = EntrySexe.Text,
            };
            AnimalRepository.AddAnimal(anim);
        }

        private void DatePickerArrivee_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.DateArrivee = e.NewDate;
        }

        private void DateDepart_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.DateDepart = e.NewDate;
        }

        private void EnclosPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIdEnclos  = EnclosPicker.SelectedIndex+1;
        }

        private void EspecePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIdEspece = EspecePicker.SelectedIndex+1;
        }
    }
}