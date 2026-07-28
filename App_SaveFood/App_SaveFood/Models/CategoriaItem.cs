using System;
using System.Collections.Generic;

namespace App_SaveFood.Models;

public partial class CategoriaItem
{
    public int IdCategoria { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
