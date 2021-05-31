using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Zoo_E4.Models
{
    [Table("Veterinaire")]
    public class Veterinaire
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nom { get; set; }

        [MaxLength(255)]
        public string Prenom { get; set; }

        [MaxLength(255)]
        public string Mail { get; set; }

        [MaxLength(255)]
        public string Login { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }
    }
}
