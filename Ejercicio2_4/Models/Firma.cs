using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_4.Models
{
    public class Firma
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string descrip { get; set; }
        public byte[] sign { get; set; }
    }
}
