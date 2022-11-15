using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string ValRol { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
