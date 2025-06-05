using Abstracciones.Abstracciones;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IClienteDAL ClienteDAL { get; set; }

        private MecaFlowContext _mecaFlowContext;

        public UnidadDeTrabajo(MecaFlowContext mecaFlowContext, IClienteDAL clienteDAL)
        {
            this._mecaFlowContext = mecaFlowContext;
            this.ClienteDAL = clienteDAL;

        }


        public bool Complete()
        {
            try
            {
                _mecaFlowContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._mecaFlowContext.Dispose();
        }
    }
}
