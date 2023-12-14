using System;
using System.Collections.Generic;

namespace AIFA_Pre.Models;

public partial class Reporte
{
    public int IdReporte { get; set; }

    public int? IdFrenteObra { get; set; }

    public int? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public int? Archivopdf { get; set; }

    public DateTime? FechaRealizado { get; set; }

    public virtual FrenteObra? IdFrenteObraNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
