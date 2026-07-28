using System;
using System.Collections.Generic;

namespace App_SaveFood.Models;

public partial class AssinaturaDescarte
{
    public int IdDescarte { get; set; }

    public int FkIdItemEstoque { get; set; }

    public int FkIdUsuario { get; set; }

    public string Assinatura { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public virtual ItemEstoque FkIdItemEstoqueNavigation { get; set; } = null!;

    public virtual Usuario FkIdUsuarioNavigation { get; set; } = null!;
}
