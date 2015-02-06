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
    public interface IRepository<T>
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> Get(Expression<Func<T, bool>> query = null); // Parameter is a lambda object which gets passed to LINQ
        T GetById(int id);
    }

    public class Repository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {

        public void Create(T obj)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<T>().Add(obj);
                ctx.SaveChanges();
            }
        }

        public void Update(T obj)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<T>().Attach(obj);
                ctx.Entry<T>(obj).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public void Delete(T obj)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<T>().Attach(obj);
                ctx.Set<T>().Remove(obj);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> query = null)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<T> result = ctx.Set<T>();
                if (query != null)
                    result = result.Where(query);
                return result.ToList();
            }
        }

        public T GetById(int id)
        {
            using (TContext ctx = new TContext())
            {
                return ctx.Set<T>().Find(id);
            }
        }        
    }

    public class RepositoryMusic<T> : Repository<T, MusicDbContext>
            where T : class
    {
    }
}
