using System;
using System.Collections.Generic;

#nullable disable

namespace Test_Amedia_20220103_GMaciel.Models
{
    public partial class TPelicula
    {
        public TPelicula()
        {
            TGeneroPeliculas = new HashSet<TGeneroPelicula>();
        }

        public int CodPelicula { get; set; }
        public string TxtDesc { get; set; }
        public int? CantDisponiblesAlquiler { get; set; }
        public int? CantDisponiblesVenta { get; set; }
        public decimal? PrecioAlquiler { get; set; }
        public decimal? PrecioVenta { get; set; }

        public virtual ICollection<TGeneroPelicula> TGeneroPeliculas { get; set; }
    }
}
