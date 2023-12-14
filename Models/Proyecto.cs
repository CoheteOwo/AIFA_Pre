using System;
using System.Collections.Generic;

namespace AIFA_Pre.Models;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string? Nombre { get; set; }

    public int? NumFrenteObra { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaEstimadaTermino { get; set; }

    public virtual ICollection<Proyectofrente> Proyectofrentes { get; } = new List<Proyectofrente>();
}
