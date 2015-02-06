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
    public class InterpreterController : ApiController
    {
        private IRepository<Interpreter> rep =
            Factory.Get<RepositoryMusic<Interpreter>>();

        private InterpreterDTO createDTO(Interpreter interpreter)
        {
            return new InterpreterDTO
            {
                InterpreterId = interpreter.InterpreterId,
                Name = interpreter.Name
            };
        }

        private Interpreter createModel(InterpreterDTO interpreterDTO)
        {
            return new Interpreter
            {
                InterpreterId = interpreterDTO.InterpreterId,
                Name = interpreterDTO.Name
            };
        }

        // GET api/interpreter
        public IEnumerable<InterpreterDTO> Get()
        {
            return rep.Get().Select(i => createDTO(i));
        }

        // GET api/interpreter/5
        public InterpreterDTO Get(int id)
        {
            return createDTO(rep.GetById(id));
        }

        // POST api/interpreter
        public void Post([FromBody]InterpreterDTO value)
        {
            rep.Create(createModel(value));
        }

        // PUT api/interpreter/5
        public void Put(int id, [FromBody]InterpreterDTO value)
        {
            rep.Update(createModel(value));
        }

        // DELETE api/interpreter/5
        public void Delete(int id)
        {
            rep.Delete(new Interpreter { InterpreterId = id });
        }
    }
}
