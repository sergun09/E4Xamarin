using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Zoo_E4.Models.Repository
{
    public class AnimalRepository
    {
        static SQLiteConnection _conn = DbHandler.getInstance().GetDb();

        public static ObservableCollection<Animal> GetAnimals(int idVet) 
        {
            var tab = _conn.Table<Animal>().Where(x => x.VeterinaireId == idVet).ToList();
            
            return new ObservableCollection<Animal>(tab);
        }

        public static void AddAnimal(Animal animal) 
        {
            _conn.Insert(animal);
        }

        public static void DeleteAnimal(int id)
        {
            if(id != 0) 
            {
                _conn.Delete<Animal>(id);
            }
        }

        public static void UpdateAnimal(Animal anim) 
        {
            _conn.Update(anim);
        }
    }
}
