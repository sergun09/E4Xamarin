using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zoo_E4.Models;
using Zoo_E4.Models.Repository;

namespace Zoo_E4.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        private ObservableCollection<Animal> _ListAnimals;

        public ObservableCollection<Animal> ListAnimal
        {
            get
            {
                return _ListAnimals ?? (AnimalRepository.GetAnimals(this.veto.Id));
            }
            set { _ListAnimals = value; }
        }

        public int SelectedItemDelete { get; set; }

        private Veterinaire veto;


        public ListViewPage(Veterinaire unVeto)
        {
            InitializeComponent();
            this.BindingContext = this;
            this.veto = unVeto;
            lblVetoName.Text = this.veto.Prenom + " " + this.veto.Nom;
            MyListView.ItemsSource = ListAnimal;
            LoadData();
        }

        private void LoadData() 
        {
            AnimalRepository.GetAnimals(this.veto.Id);
        } 

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;


            var AnimalSelected = ((Animal)e.Item);
            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            await Navigation.PushAsync(new PageDetailAnimal(AnimalSelected, veto));
        }
        

        private void AddAnimal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage(this.veto));
        }

        protected override void OnAppearing()
        {
               
        }
    }
}
