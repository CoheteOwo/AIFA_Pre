using System;
using System.Collections.Generic;

namespace AIFA_Pre.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdFrenteObra { get; set; }

    public int? IdRol { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Pass { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public virtual FrenteObra? IdFrenteObraNavigation { get; set; }

    public virtual RolUsuario? IdRolNavigation { get; set; }

    public virtual ICollection<Reporte> Reportes { get; } = new List<Reporte>();
}
