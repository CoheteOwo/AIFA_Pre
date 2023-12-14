using System;
using System.Collections.Generic;

namespace AIFA_Pre.Models;

public partial class FrenteObra
{
    public int IdFrenteObra { get; set; }

    public int? Idconst { get; set; }

    public int? IdProyectofrent { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaEstimadaTermino { get; set; }

    public virtual Proyectofrente? IdProyectofrentNavigation { get; set; }

    public virtual Constructora? IdconstNavigation { get; set; }

    public virtual ICollection<Reporte> Reportes { get; } = new List<Reporte>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
