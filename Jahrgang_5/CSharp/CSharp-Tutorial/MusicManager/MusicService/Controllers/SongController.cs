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
    public class SongController : ApiController
    {
        private IRepository<Song> rep = Factory.Get<RepositoryMusic<Song>>();

        private SongDTO createDTO(Song song)
        {
            return new SongDTO
            {
                SongId = song.SongId,
                Name = song.Name,
                Duration = song.Duration,
                AlbumId = song.AlbumId,
                InterpreterId = song.InterpreterId,
                //Album = new AlbumDTO
                //{
                //    AlbumId = song.Album.AlbumId,
                //    Name = song.Album.Name,
                //    Year = song.Album.Year
                //}
            };
        }

        private Song createModel(SongDTO songDTO)
        {
            return new Song
            {
                SongId = songDTO.SongId,
                Name = songDTO.Name,
                Duration = songDTO.Duration,
                AlbumId = songDTO.AlbumId,
                InterpreterId = songDTO.InterpreterId
            };
        }

        // GET api/songs
        public IEnumerable<SongDTO> Get()
        {
            return rep.Get().Select(song => createDTO(song));
        }

        // GET api/song/5
        public SongDTO Get(int id)
        {
            Song song = rep.GetById(id);
            return createDTO(song);
        }

        // GET api/song?interpreterid=5
        public IEnumerable<SongDTO> GetByInterpreterId(int interpreterid)
        {            
            return rep.Get(song => song.InterpreterId == interpreterid).Select(song => createDTO(song));
        }

        // POST api/songs
        public void Post([FromBody]SongDTO value)
        {
            rep.Create(createModel(value));
        }

        // PUT api/songs/5
        public void Put(int id, [FromBody]SongDTO value)
        {
            rep.Update(createModel(value));
        }

        // DELETE api/songs/5
        public void Delete(int id)
        {
            rep.Delete(new Song { SongId = id });
        }        
    }
}
