using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ItemReceitum
{
    public int IdItemReceita { get; set; }

    public int FkIdReceita { get; set; }

    public int FkIdItem { get; set; }

    public decimal Quantidade { get; set; }

    public int FkIdUnidade { get; set; }

    public virtual Item FkIdItemNavigation { get; set; } = null!;

    public virtual Receitum FkIdReceitaNavigation { get; set; } = null!;

    public virtual UnidadeMedidum FkIdUnidadeNavigation { get; set; } = null!;
}
