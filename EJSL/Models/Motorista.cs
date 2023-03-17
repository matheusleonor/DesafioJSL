using System;
using System.Collections.Generic;

namespace EJSL.Models;

public partial class Motorista
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string TipoHabilitacao { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<Viagem> Viagems { get; } = new List<Viagem>();
}
