using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Semana5_Ejercisio1.Models
{
    [Table("Personas")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]

        public string Name { get; set; }
    }
}

