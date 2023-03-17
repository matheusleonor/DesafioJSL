using System;
using System.Collections.Generic;

namespace EJSL.Models;

public partial class Viagem
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int MotoristaId { get; set; }

    public int RotaId { get; set; }

    public int VeiculoId { get; set; }

    public bool? Status { get; set; }

    public virtual Motorista Motorista { get; set; } = null!;

    public virtual Rota Rota { get; set; } = null!;

    public virtual Veiculo Veiculo { get; set; } = null!;
}
