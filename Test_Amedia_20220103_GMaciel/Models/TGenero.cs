using System;
using System.Collections.Generic;

#nullable disable

namespace Test_Amedia_20220103_GMaciel.Models
{
    public partial class TGenero
    {
        public TGenero()
        {
            TGeneroPeliculas = new HashSet<TGeneroPelicula>();
        }

        public int CodGenero { get; set; }
        public string TxtDesc { get; set; }

        public virtual ICollection<TGeneroPelicula> TGeneroPeliculas { get; set; }
    }
}
