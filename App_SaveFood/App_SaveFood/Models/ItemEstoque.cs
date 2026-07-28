using System;
using System.Collections.Generic;

namespace App_SaveFood.Models;

public partial class ItemEstoque
{
    public int IdItemEstoque { get; set; }

    public int FkIdItem { get; set; }

    public int FkIdRestaurante { get; set; }

    public DateOnly DataValidade { get; set; }

    public string? Status { get; set; }

    public decimal Quantidade { get; set; }

    public int? FkIdUnidade { get; set; }

    public virtual ICollection<AssinaturaDescarte> AssinaturaDescartes { get; set; } = new List<AssinaturaDescarte>();

    public virtual Item FkIdItemNavigation { get; set; } = null!;

    public virtual Restaurante FkIdRestauranteNavigation { get; set; } = null!;

    public virtual UnidadeMedidum? FkIdUnidadeNavigation { get; set; }
}
