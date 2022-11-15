using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class Documento
    {
        public Documento()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoDoc { get; set; }
        public string ValTipoDoc { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
