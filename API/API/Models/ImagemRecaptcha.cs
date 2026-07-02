using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ImagemRecaptcha
{
    public int IdImagemRecaptcha { get; set; }

    public int? FkIdCategoriaRecaptcha { get; set; }

    public string? Imagem { get; set; }

    public virtual CategoriaRecaptcha? FkIdCategoriaRecaptchaNavigation { get; set; }
}
