using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Zoo_E4.Models
{
    [Table("Soins")]
    public class Soins
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int AnimalId { get; set; }

        [Indexed]
        public int VeterinaireId { get; set; }


        public DateTime Datesoins { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public float Poids { get; set; }
    }
}
