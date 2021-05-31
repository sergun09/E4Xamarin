using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Zoo_E4.Models
{
    public class DbHandler
    {
        private SQLiteConnection _conn;
        private static DbHandler singleton = null;


        public DbHandler()
        {
            try
            {
                _conn = new SQLiteConnection(App.FilePath, storeDateTimeAsTicks: false);
                _conn.CreateTable<Veterinaire>();
                _conn.CreateTable<Soins>();
                _conn.CreateTable<Animal>();
                _conn.CreateTable<Espece>();
                _conn.CreateTable<Enclos>();
                _conn.CreateTable<TypeEnclos>();

                // Supprimer toutes les données
                //_db.DeleteAllAsync<Veterinaire>();
                //_db.DeleteAllAsync<TypeEnclos>();
                //_db.DeleteAllAsync<Enclos>();
                //_db.DeleteAllAsync<Soins>();
                //_db.DeleteAllAsync<Animal>();
                //_db.DeleteAllAsync<Espece>();

                // Insertion des données Vétérinaires
                //_conn.Insert(new Veterinaire()
                //{
                //    Nom = "Sola",
                //    Prenom = "Camille",
                //    Mail = "camille.sola@zoo.fr",
                //    Login = "camille.sola33",
                //    Password = "root123"
                //});

                //// Insertion des données TypeEnclos
                //_conn.InsertAll(new List<TypeEnclos>()
                //{
                //    new TypeEnclos(){Libelle = "Aquarium"},
                //    new TypeEnclos(){Libelle = "Végétation"},
                //});

                // Insertion des données Enclos
                //_conn.InsertAll(new List<Enclos>()
                //{
                //    new Enclos(){TypeEnclosId=1, Nom="Odyssée des Mers"},
                //    new Enclos(){TypeEnclosId= 2, Nom="Jungle des Parnaz"}
                //});

                // Insertion des données Espece
                //_conn.InsertAll(new List<Espece>()
                //{
                //    new Espece(){Nom="Panda Roux", Regimealimentaire="Herbivore"},
                //    new Espece(){Nom="Requin Marteau", Regimealimentaire="Carnivore"},
                //    new Espece(){Nom="Puma d'Afrique", Regimealimentaire="Carnivore"},
                //    new Espece(){Nom="Beluga", Regimealimentaire="Varié"},
                //});

                // Insertion des données Animal
                //_conn.InsertAll(new List<Animal>()
                //{
                //    new Animal(){ EspeceId = 2, EnclosId = 1, VeterinaireId = 1,  Nom = "Lamna", Sexe="M", DateDepart=new DateTime(2022,02,08), DateArrivee = new DateTime(2019,06,15) }
                //});


                // Insertion des données soins
            }
            catch (Exception e)
            {
                throw new Exception($"Impossible de communiquer avec la BDD : {e.Message}");
            }
        }

        public static DbHandler getInstance() 
        {
            if(singleton == null) 
            {
                singleton = new DbHandler();
            }

            return singleton;
        }

        public SQLiteConnection GetDb()
        {
            return this._conn;
        }
    }
}
