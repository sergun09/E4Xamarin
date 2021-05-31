using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Zoo_E4.Models
{
    [Table("Enclos")]
    public class Enclos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int TypeEnclosId { get; set; }

        [MaxLength(255)]
        public string Nom { get; set; }
    }
}
