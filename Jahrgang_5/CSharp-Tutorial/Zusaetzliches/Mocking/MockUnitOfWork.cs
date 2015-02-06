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

using DataLayerSchool.Entities;
using DataLayerSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerSchool.Mocking
{
    class MockUnitOfWork : IUnitOfWork
    {
        List<object> reps = new List<object>();

        public IRepository<T> GetRep<T>() where T : class
        {
            var rep = reps.SingleOrDefault(r => r is IRepository<T>);
            if (rep == null)
            {
                rep = Factory.Get<IRepository<T>>();
                reps.Add(rep);
            }
            return rep as IRepository<T>;
        }

        public void Save()
        {
            
        }
    }
}
