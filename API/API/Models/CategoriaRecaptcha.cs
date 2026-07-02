using System;
using System.Collections.Generic;

namespace API.Models;

public partial class CategoriaRecaptcha
{
    public int IdCategoriaRecaptcha { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<ImagemRecaptcha> ImagemRecaptchas { get; set; } = new List<ImagemRecaptcha>();
}
