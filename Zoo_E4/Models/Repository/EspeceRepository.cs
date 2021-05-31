using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_E4.Models.Repository
{
    class EspeceRepository
    {
        static SQLiteConnection _conn = DbHandler.getInstance().GetDb();

        public static ObservableCollection<Espece> GetAllEspeces()
        {
            return new ObservableCollection<Espece>(_conn.Table<Espece>().ToList());
        }

        public static Espece GetSingleEspece(int id) 
        {
            Espece esp = _conn.Table<Espece>().FirstOrDefault(x => x.Id == id);
            return esp;
        }
    }
}
