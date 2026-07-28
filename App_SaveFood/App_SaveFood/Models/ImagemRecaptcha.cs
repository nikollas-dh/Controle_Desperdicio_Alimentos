using System;
using System.Collections.Generic;

namespace App_SaveFood.Models;

public partial class ImagemRecaptcha
{
    public int IdImagemRecaptcha { get; set; }

    public int? FkIdCategoriaRecaptcha { get; set; }

    public string? Imagem { get; set; }

    public virtual CategoriaRecaptcha? FkIdCategoriaRecaptchaNavigation { get; set; }
}
