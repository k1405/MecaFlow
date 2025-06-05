using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Abstracciones;

public partial class ReportesFinanciero
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Ingresos { get; set; }

    public decimal Gastos { get; set; }
}
