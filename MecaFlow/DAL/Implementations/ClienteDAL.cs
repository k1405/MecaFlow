using Abstracciones.Abstracciones;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ClienteDAL : DALGenericoImpl<Cliente>, IClienteDAL
    {
        private MecaFlowContext _context;

        public ClienteDAL(MecaFlowContext context) : base(context)
        {
            _context = context;
        }
        public List<Cliente> GetAllClientes()
        {
            string query = "sp_GetAllClientes";

            var resul = _context.Clientes.FromSqlRaw(query);


            return resul.ToList();
        }

        public bool Add(Cliente entity)
        {
            try
            {
                string sql = "exec [dbo].[sp_AddCliente] @Nombre, @Telefono";

                var param = new SqlParameter[]
                {
            new SqlParameter
            {
                ParameterName = "@Nombre",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = entity.Nombre
            },
            new SqlParameter
            {
                ParameterName = "@Telefono",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = (object?)entity.Telefono ?? DBNull.Value
            }
                };

                _context
                    .Database
                    .ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception e)
            {
                // Optionally log the exception
                return false;
            }
        }


        public bool Update(Cliente entity)
        {
            try
            {
                _context.Clientes.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Clientes.Find(id);
                if (entity != null)
                {
                    _context.Clientes.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
