using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Zoo_E4.Models.Repository
{
    public partial class SoinsRepository
    {
        static SQLiteConnection _conn = DbHandler.getInstance().GetDb();

        public static ObservableCollection<Soins> GetAllSoinsByAnimal(int id) 
        {
            return new ObservableCollection<Soins>(_conn.Table<Soins>().Where(x => x.AnimalId == id));
        }

        public static ObservableCollection<Soins> GetAllSoinsBetweenTwoDates(DateTime FromDate, DateTime ToDate) 
        {
            string query = $"Select * from Soins where Datesoins BETWEEN '{FromDate}' and '{ToDate}'";
            var res =_conn.Query<Soins>(query);
            return new ObservableCollection<Soins>(res);
        }

        public static void UpdateSoins(Soins soins) 
        {
            _conn.Update(soins);
        }

        public static void AddSoins(Soins anim) 
        {
            _conn.Insert(anim);
        }

        public static void DeleteSoins(int id)
        {
            if (id != 0)
            {
                _conn.Delete<Soins>(id);
            }
        }
    }
}
