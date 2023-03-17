using System;
using System.Collections.Generic;

namespace EJSL.Models;

public partial class Veiculo
{
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public string Placa { get; set; } = null!;

    public int Ano { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Viagem> Viagems { get; } = new List<Viagem>();
}
