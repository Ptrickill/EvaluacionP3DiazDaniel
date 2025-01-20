using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using EvaluacionP3DiazDaniel.Models;

namespace EvaluacionP3DiazDaniel.Models
{
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string GoogleMapsLink { get; set; }  
        public string CustomName { get; set; }
    }
}
