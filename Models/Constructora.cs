using System;
using System.Collections.Generic;

namespace AIFA_Pre.Models;

public partial class Constructora
{
    public int Idconst { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public int? Numerocon { get; set; }

    public virtual ICollection<FrenteObra> FrenteObras { get; } = new List<FrenteObra>();
}
