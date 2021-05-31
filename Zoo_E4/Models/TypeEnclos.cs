using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Zoo_E4.Models
{
    [Table("TypeEnclos")]
    public class TypeEnclos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Libelle { get; set; }
    }
}
