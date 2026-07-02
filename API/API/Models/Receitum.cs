using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Receitum
{
    public int IdReceita { get; set; }

    public string Nome { get; set; } = null!;

    public string ModoPreparo { get; set; } = null!;

    public string? Foto { get; set; }

    public virtual ICollection<ItemReceitum> ItemReceita { get; set; } = new List<ItemReceitum>();
}
