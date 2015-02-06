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

using DataLayerSchool;
using DataLayerSchool.Entities;
using DataLayerSchool.Mocking;
using DataLayerSchool.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerSchool
{
    public static class Factory
    {
        static private IKernel kernel;
        static Factory()
        {
            kernel = new StandardKernel();
            CreateBindings();
            //CreateMockBindings();
           
        }

        private static void CreateMockBindings()
        {
            kernel.Bind<IUnitOfWork>().To<MockUnitOfWork>();

            Class[] classes = new Class[] { 
                new Class { ClassId=1, Description="5AHIF" },
                new Class { ClassId=2, Description="5BHIF" },
                new Class { ClassId=3, Description="4AHIF" }
            };

            Pupil[] pupils = new Pupil[] {
                new Pupil { PersonId=1, CatalogNo=1, Firstname="Martin", Lastname="Wahlmüller", ClassId=1, Class = classes[0] },
                new Pupil { PersonId=2, CatalogNo=2, Firstname="Sophie", Lastname="Seyer", ClassId=1, Class = classes[0] },
                new Pupil { PersonId=3, CatalogNo=1, Firstname="Daniel", Lastname="Holzmann", ClassId=2, Class = classes[1] },
                new Pupil { PersonId=4, CatalogNo=2, Firstname="Daniel", Lastname="Diesenreiter", ClassId=2, Class = classes[1] }
            };

            kernel.Bind<IRepository<Class>>()
                  .To<MockRepository<Class>>()
                  .WithConstructorArgument("init", classes);
            kernel.Bind<IRepository<Pupil>>()
                  .To<MockRepository<Pupil>>()
                  .WithConstructorArgument("init", pupils);
        }

        private static void CreateBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            kernel.Bind<IRepository<Class>>().To<RepositorySchool<Class>>();
            kernel.Bind<IRepository<Pupil>>().To<RepositorySchool<Pupil>>();
        }

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }
    }
}
