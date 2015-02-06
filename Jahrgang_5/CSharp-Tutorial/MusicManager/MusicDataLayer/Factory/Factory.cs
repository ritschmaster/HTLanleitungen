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

using MusicDataLayer.UnitOfWork;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDataLayer
{
    public static class Factory
    {
        private static IKernel kernel;

        static Factory()
        {
            kernel = new StandardKernel();
            CreateBindings();
            //CreateMockBindings();
        }

        private static void CreateMockBindings()
        {
            //kernel.Bind<IUnitOfWork>()
            //    .To<MockUnitOfWork>();
        }

        private static void CreateBindings()
        {
            kernel.Bind<IUnitOfWork>()
                .To<MusicUnitOfWork>();

            kernel.Bind<IRepository<Song>>().To<RepositoryMusic<Song>>();
            kernel.Bind<IRepository<Album>>().To<RepositoryMusic<Album>>();
            kernel.Bind<IRepository<Interpreter>>().To<RepositoryMusic<Interpreter>>();
        }

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }
    }
}
