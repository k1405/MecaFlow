using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Abstracciones;
    public partial class Asistencia
    {
        public int Id { get; set; }

        public int EmpleadoId { get; set; }

        public DateOnly Fecha { get; set; }

        public string? Estado { get; set; }

        public virtual Empleado Empleado { get; set; } = null!;
    }
