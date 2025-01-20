using Kotlin.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionP3DiazDaniel.Modelos
{
    public class PaisModel
    {
        public string Name {  get; set; }
        public string Region { get; set; }
        public Maps Maps { get; set; }

    }
    public class Maps
    {
        public string GoogleMaps { get; set; }
    }

    public class PaisDb
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Region {  set; get; }
        public string LinkMaps { get; set; }
}
