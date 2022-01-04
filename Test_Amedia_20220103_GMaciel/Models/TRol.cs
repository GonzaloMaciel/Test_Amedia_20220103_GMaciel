using System;
using System.Collections.Generic;

#nullable disable

namespace Test_Amedia_20220103_GMaciel.Models
{
    public partial class TRol
    {
        public TRol()
        {
            TUsers = new HashSet<TUser>();
        }

        public int CodRol { get; set; }
        public string TxtDesc { get; set; }
        public int? SnActivo { get; set; }

        public virtual ICollection<TUser> TUsers { get; set; }
    }
}
