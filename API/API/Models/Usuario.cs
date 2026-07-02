using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int FkIdRestaurante { get; set; }

    public string Nome { get; set; } = null!;

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public string? Pin { get; set; }

    public int? TentativasPin { get; set; }

    public DateTime? BloqueioPin { get; set; }
    [JsonIgnore]
    public virtual ICollection<AssinaturaDescarte> AssinaturaDescartes { get; set; } = new List<AssinaturaDescarte>();
    [JsonIgnore]
    public virtual Restaurante FkIdRestauranteNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<TentativaRecaptcha> TentativaRecaptchas { get; set; } = new List<TentativaRecaptcha>();
}
