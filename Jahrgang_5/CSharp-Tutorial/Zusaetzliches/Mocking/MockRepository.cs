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

using DataLayerSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerSchool.Mocking
{
    public class MockRepository<T> : IRepository<T>
    {
        private List<T> list = new List<T>();

        public MockRepository(IEnumerable<T> init)
        {
            list.AddRange(init);
        }

        public void Create(T entity)
        {
            list.Add(entity);
        }

        public void Update(T entity)
        {
            Delete(entity);
            Create(entity);
        }

        public void Delete(T entity)
        {
            this.list.Remove(GetById(entity.Id()));
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> query = null)
        {
            var result = this.list.AsQueryable();
            if (query != null)
                result = result.Where(query);

            return result.ToList();
        }

        public T GetById(int id)
        {
            return list.SingleOrDefault(item => item.Id() == id);
        }
    }

    static class ItemExtensions
    {
        public static int Id<T>(this T item)
        {
            Type type = typeof(T);
            while (type.BaseType != typeof(Object))
                type = type.BaseType;
            return (int)type.GetProperty(type.Name + "Id").GetValue(item);
        }
    }
}
