using System;
using System.Collections.Generic;

namespace AIFA_Pre.Models;

public partial class Proyectofrente
{
    public int IdProyectofrent { get; set; }

    public int? Idproyecto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaEstimadaTermino { get; set; }

    public virtual ICollection<FrenteObra> FrenteObras { get; } = new List<FrenteObra>();

    public virtual Proyecto? IdproyectoNavigation { get; set; }
}
