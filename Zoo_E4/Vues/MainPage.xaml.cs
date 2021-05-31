using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zoo_E4.Models;
using Zoo_E4.Models.Repository;
using SQLite;

namespace Zoo_E4.Vues
{
    public partial class MainPage : ContentPage
    {
        private VeterinaireRepository VetoRepo;

        public MainPage()
        {
            InitializeComponent();
            this.VetoRepo = new VeterinaireRepository();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            Veterinaire vet =  this.VetoRepo.GetSingleVeterinaire(loginEntry.Text);
            Console.WriteLine($"Infos : {vet.Id}, {vet.Nom}, {vet.Prenom}, {vet.Mail}, {vet.Login}, {vet.Password} ");
            if (vet.Login == loginEntry.Text && vet.Password == passwordEntry.Text)
            {
                Navigation.PushAsync(new ListViewPage(vet));
                lblError.IsVisible = false;
            }
            else
            {
                lblError.IsVisible = true;
            }
        }
    }

}

