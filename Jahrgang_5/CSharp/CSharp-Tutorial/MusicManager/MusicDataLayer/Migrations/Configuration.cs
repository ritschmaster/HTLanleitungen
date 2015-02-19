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

namespace MusicDataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicDataLayer.MusicDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MusicDataLayer.MusicDbContext context)
        {
            // Delete old stuff
context.Albums.RemoveRange(context.Albums.ToList());
context.Songs.RemoveRange(context.Songs.ToList());
context.Interpreters.RemoveRange(context.Interpreters.ToList());
// Make some fresh stuff
Interpreter inter1 = new Interpreter()
{
Name = "Gordon Goodwin Big Phat Band",
Songs = new List<Song>()
{
new Song()
{
Name = "Backrow Politics",
Duration = 180,
Album = new Album()
{
Name = "Album1", Year = 2015
}
},
new Song()
{
Name = "The Jazz Police",
Duration = 180,
Album = new Album()
{
Name = "Album2", Year = 2014
}
}
}
};
Album albumMingus = new Album()
{
Name = "Mingus Album",
Year = 2015
};
Interpreter inter2 = new Interpreter()
{
Name = "Charles Mingus Big Band",
Songs = new List<Song>()
{
new Song()
{
Name = "Moanin’",
Duration = 180,
Album = albumMingus
},
new Song()
{
Name = "Ecclusiastics",
Duration = 180,
Album = albumMingus
},
new Song()
{
Name = "Invisible lady",
Duration = 180,
Album = albumMingus
}
}
};
Interpreter inter3 = new Interpreter()
{
    Name = "Dave Brubeck",
    Songs = new List<Song>()
{
new Song()
{
Name = "Take five",
Duration = 177,
Album = new Album()
{
Name = "Dave", Year = 1975
}
}
}
};
// Populate the database with the fresh stuff
context.Interpreters.AddOrUpdate(inter1);
context.Interpreters.AddOrUpdate(inter2);
context.Interpreters.AddOrUpdate(inter3);
context.SaveChanges();


        }
    }
}
