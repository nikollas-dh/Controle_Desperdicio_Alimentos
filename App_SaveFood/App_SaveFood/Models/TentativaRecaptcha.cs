using System;
using System.Collections.Generic;

namespace App_SaveFood.Models;

public partial class TentativaRecaptcha
{
    public int IdTentativa { get; set; }

    public int FkIdUsuario { get; set; }

    public string Resultado { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public virtual Usuario FkIdUsuarioNavigation { get; set; } = null!;
}
