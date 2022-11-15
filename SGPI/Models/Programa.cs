using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class Programa
    {
        public Programa()
        {
            Homologacions = new HashSet<Homologacion>();
            Modulos = new HashSet<Modulo>();
            Programacions = new HashSet<Programacion>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPrograma { get; set; }
        public string ValPrograma { get; set; }
        public string Pensum { get; set; }

        public virtual ICollection<Homologacion> Homologacions { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Programacion> Programacions { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
