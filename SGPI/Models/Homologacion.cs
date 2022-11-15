using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class Homologacion
    {
        public int IdHomologacion { get; set; }
        public DateTime? FechaHomologacion { get; set; }
        public string Universidad { get; set; }
        public int? IdPrograma { get; set; }
        public int? IdModulo { get; set; }
        public double? Nota { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; }
        public virtual Programa IdProgramaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
