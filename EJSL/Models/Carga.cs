using System;
using System.Collections.Generic;

namespace EJSL.Models;

public partial class Carga
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public decimal Peso { get; set; }

    public string Produto { get; set; } = null!;

    public int Quantidade { get; set; }

    public string Origem { get; set; } = null!;

    public string Destino { get; set; } = null!;

    public bool? Status { get; set; }
}
