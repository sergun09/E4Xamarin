using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Zoo_E4.Models
{
    [Table("Espece")]
    public class Espece
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255), Unique]
        public string Nom { get; set; }

        [MaxLength(255)]
        public string Regimealimentaire { get; set; }


        public string FullName() 
        {
            return this.Nom + " " + this.Regimealimentaire;
        }
    }
    
    
}
