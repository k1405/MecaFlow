using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Abstracciones;

public partial class Factura
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Monto { get; set; }

    public string? Estado { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
