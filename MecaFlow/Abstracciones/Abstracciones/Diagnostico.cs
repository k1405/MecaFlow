using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Abstracciones;

public partial class Diagnostico
{
    public int Id { get; set; }

    public int VehiculoId { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Descripcion { get; set; }

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}
