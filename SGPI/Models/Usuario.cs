using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Entrevista = new HashSet<Entrevistum>();
            Homologacions = new HashSet<Homologacion>();
            Pagos = new HashSet<Pago>();
            ProgramaUsuarios = new HashSet<ProgramaUsuario>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdGenero { get; set; }
        public int? IdTipoDoc { get; set; }
        public string Documento { get; set; }
        public int? IdPrograma { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int? IdRol { get; set; }
        public string Direccion { get; set; }
        public string Contraseña { get; set; }
        public bool? Egresado { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Programa IdProgramaNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual Documento IdTipoDocNavigation { get; set; }
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<Homologacion> Homologacions { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<ProgramaUsuario> ProgramaUsuarios { get; set; }
    }
}
