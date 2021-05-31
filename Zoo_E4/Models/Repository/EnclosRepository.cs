using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_E4.Models.Repository
{
    public class EnclosRepository
    {
        static SQLiteConnection _conn = DbHandler.getInstance().GetDb();

        public static ObservableCollection<Enclos> GetAllEnclos() 
        {
            return new ObservableCollection<Enclos>(_conn.Table<Enclos>().ToList());
        }

        public static ObservableCollection<string> GetAllEnclosString()
        {
            var s = new ObservableCollection<string>();
            foreach (var item in _conn.Table<Enclos>().ToList())
            {
                s.Add(item.Nom);
            }
            return s;
        }
    }
}
