using System;
using System.Collections.Generic;

namespace EJSL.Models;

public partial class Rota
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<Viagem> Viagems { get; } = new List<Viagem>();
}
