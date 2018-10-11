using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Libreria.Models
{   
    [Table("Publicacion")]
    public class Publicacion
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int MeGusta { get; set; }
        public int MeDisgusta { get; set; }
        public int VecesCompartido { get; set; }
        public bool EsPrivado { get; set; }

    }
}
