using System;
using System.Collections.Generic;

namespace App_SaveFood.Models;

public partial class Restaurante
{
    public int IdRestaurante { get; set; }

    public string Nome { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Logotipo { get; set; }

    public virtual ICollection<ItemEstoque> ItemEstoques { get; set; } = new List<ItemEstoque>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
