using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zoo_E4.Models;

namespace Zoo_E4.Vues.Soins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPageSoins : ContentPage
    {
        

        public ObservableCollection<Zoo_E4.Models.Soins> ListSoins
        {
            get
            {
                return Zoo_E4.Models.Repository.SoinsRepository.GetAllSoinsByAnimal(this.CurrentAnimal.Id);
            }
            set 
            {
                ListSoins = value;
                base.OnPropertyChanged("ListSoins");
            }
        }

        public Animal CurrentAnimal { get; set; }

        public ListViewPageSoins(Veterinaire veto, Animal animal)
        {
            InitializeComponent();

            this.CurrentAnimal = animal;


            MyListView.ItemsSource = ListSoins;
        }

        protected override void OnAppearing()
        {
            Zoo_E4.Models.Repository.SoinsRepository.GetAllSoinsByAnimal(this.CurrentAnimal.Id);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var SoinsSelected = ((Zoo_E4.Models.Soins)e.Item);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            await Navigation.PushAsync(new PageDetailSoins(SoinsSelected));
        }

        private void AddSoins_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddSoinsPage(this.CurrentAnimal));
        }

        private void ButtonSearch_Clicked(object sender, EventArgs e)
        {
            var FromDate = this.DatePickerFrom.Date;
            var ToDate = this.DatePickerTo.Date;
            if(FromDate != null && ToDate != null) 
            {
                this.ListSoins = Zoo_E4.Models.Repository.SoinsRepository.GetAllSoinsBetweenTwoDates(this.DatePickerFrom.Date, this.DatePickerTo.Date);
            }
            else 
            {
                DisplayAlert("Notification Date", "Veuillez entrer 2 dates", "Ok");
            }
            
        }
    }
}
