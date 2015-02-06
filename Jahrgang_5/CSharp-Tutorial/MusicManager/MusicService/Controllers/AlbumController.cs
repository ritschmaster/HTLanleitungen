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

using MusicDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicService.Controllers
{
    public class AlbumController : ApiController
    {
        private IRepository<Album> rep = 
            Factory.Get<RepositoryMusic<Album>>();

        private AlbumDTO createDTO(Album album)
        {
            return new AlbumDTO
            {
                AlbumId = album.AlbumId,
                Name = album.Name,
                Year = album.Year
            };
        }

        private Album createModel(AlbumDTO albumDTO)
        {
            return new Album
            {
                AlbumId = albumDTO.AlbumId,
                Name = albumDTO.Name,
                Year = albumDTO.Year
            };
        }

        // GET api/album
        public IEnumerable<AlbumDTO> Get()
        {
            return rep.Get().Select(a => createDTO(a));
        }

        // GET api/album/5
        public AlbumDTO Get(int id)
        {
            return createDTO(rep.GetById(id));
        }

        // POST api/album
        public void Post([FromBody]AlbumDTO value)
        {
            rep.Create(createModel(value));
        }

        // PUT api/album/5
        public void Put(int id, [FromBody]AlbumDTO value)
        {
            rep.Update(createModel(value));
        }

        // DELETE api/album/5
        public void Delete(int id)
        {
            rep.Delete(new Album { AlbumId = id });
        }
    }
}
