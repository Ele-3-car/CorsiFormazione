using CorsiFormazione.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _context;

        public GenericRepository(MyDbContext context)
        {
            _context = context;
        }

        public void Aggiungi(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Elimina(object nome)
        {
            var entity = Ottieni(nome);
            _context.Entry(entity).State = EntityState.Deleted;
        }

        private object Ottieni(object nome)
        {
            return _context.Set<T>().Find(nome);
        }
    }
}
