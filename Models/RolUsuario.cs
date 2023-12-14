using System;
using System.Collections.Generic;

namespace AIFA_Pre.Models;

public partial class RolUsuario
{
    public int IdRol { get; set; }

    public string? Nombredelrol { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
