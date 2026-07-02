using System;
using System.Collections.Generic;

namespace API.Models;

public partial class UnidadeMedidum
{
    public int IdUnidade { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<ItemEstoque> ItemEstoques { get; set; } = new List<ItemEstoque>();

    public virtual ICollection<ItemReceitum> ItemReceita { get; set; } = new List<ItemReceitum>();
}
