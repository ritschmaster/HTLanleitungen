/************************************************************************
 * Copyright (C) 2015 Richard Bäck <richard.baeck@openmailbox.org>
 *
 * This file is part of assets-cli.
 *
 * assets-cli is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * assets-cli is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with assets-cli.  If not, see <http://www.gnu.org/licenses/>.
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicDataLayer
{
    public class RepositoryUow<T> : IRepository<T>
        where T: class
    {
        private DbContext _context;

        public RepositoryUow(DbContext context)
        {
            _context = context;
        }

        public void Create(T obj)
        {
            _context.Set<T>().Add(obj);
        }

        public void Update(T obj)
        {
            if (_context.Entry<T>(obj).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(obj);
            }
            _context.Entry<T>(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            if (_context.Entry<T>(obj).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(obj);
            }
            _context.Set<T>().Remove(obj);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> query = null)
        {
            IQueryable<T> result = _context.Set<T>();
            if (query != null)
                result = result.Where(query);
            return result.ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
