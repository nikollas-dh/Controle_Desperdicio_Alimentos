using System;
using System.Collections.Generic;

namespace App_SaveFood.Models;

public partial class Item
{
    public int IdItem { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public string? Foto { get; set; }

    public int FkIdCategoria { get; set; }

    public virtual CategoriaItem FkIdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<ItemEstoque> ItemEstoques { get; set; } = new List<ItemEstoque>();

    public virtual ICollection<ItemReceitum> ItemReceita { get; set; } = new List<ItemReceitum>();
}
