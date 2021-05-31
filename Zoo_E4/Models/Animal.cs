using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Zoo_E4.Models
{
    [Table("Animal")]
    public class Animal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int EspeceId { get; set; }

        [Indexed]
        public int EnclosId { get; set; }

        [Indexed]
        public int VeterinaireId { get; set; }

        [MaxLength(255)]
        public string Nom { get; set; }

        [MaxLength(255)]
        public string Sexe { get; set; }

        [MaxLength(255)]
        public string UrlImage { get; set; }

        public DateTime DateArrivee { get; set; }
        public DateTime DateDepart { get; set; }
    }
}
