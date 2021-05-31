using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Zoo_E4.Models.Repository
{
    public class VeterinaireRepository
    {
        SQLiteConnection _conn = DbHandler.getInstance().GetDb();

        public Veterinaire GetSingleVeterinaire(string login)
        {

            Veterinaire SingleVeto = new Veterinaire();

            SingleVeto =  this._conn.Table<Veterinaire>().Where(v => v.Login == login).FirstOrDefault();

            var s = _conn.Table<Enclos>().Count();
            var ve = _conn.Table<Veterinaire>().Count();

            Console.WriteLine("Nb Enclos : " + s);
            Console.WriteLine("Nb veto : " + ve);
            Console.WriteLine("nb Type Enclos : " + _conn.Table<Soins>().Count());
            Console.WriteLine("nb Especes : " + _conn.Table<Espece>().Count());
            Console.WriteLine("nb Especes : " + _conn.Table<Animal>().Count());

            return SingleVeto;
        }
    }
}
