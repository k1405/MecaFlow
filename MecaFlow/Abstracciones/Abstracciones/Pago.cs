using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Abstracciones;

public partial class Pago
{
    public int Id { get; set; }

    public int FacturaId { get; set; }

    public DateOnly FechaPago { get; set; }

    public decimal Monto { get; set; }

    public virtual Factura Factura { get; set; } = null!;
}
