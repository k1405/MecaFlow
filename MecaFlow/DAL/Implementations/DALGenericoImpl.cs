using Abstracciones.Abstracciones;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        private MecaFlowContext _mecaFlowContext;

        public DALGenericoImpl(MecaFlowContext mecaFlowContext)
        {

            _mecaFlowContext = mecaFlowContext;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _mecaFlowContext.Add(entity);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public TEntity Get(int id)
        {

            return _mecaFlowContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _mecaFlowContext.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _mecaFlowContext.Set<TEntity>().Attach(entity);
                _mecaFlowContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _mecaFlowContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
