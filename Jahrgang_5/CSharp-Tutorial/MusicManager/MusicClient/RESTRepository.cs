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
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MusicClient
{
    public class RESTRepository
    {
        private HttpClient client;
        private JavaScriptSerializer serializer = new JavaScriptSerializer();

        public RESTRepository(string baseUrl)
        {
            client = new HttpClient { BaseAddress = new Uri(baseUrl) };            
        }

        // e.g.: InterpreterDTO -> Interpreter
        private string RemoveDTO<T>()
        {
            var name = typeof(T).Name;
            name = name.Substring(0, name.Length - 3);
            return name;
        }

        public void Create<T>(T obj)
        {
            var json = serializer.Serialize(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.PostAsync(RemoveDTO<T>(), content);
        }

        public void Update<T>(T obj, int id)
        {
            var json = serializer.Serialize(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.PutAsync(RemoveDTO<T>() + "/" + id.ToString(), content);
        }

        public void Delete<T>(T obj, int id)
        {
            client.DeleteAsync(RemoveDTO<T>() + id.ToString());
        }

        public IEnumerable<T> Get<T>(string query = "")
        {

            var result = client.GetStringAsync(RemoveDTO<T>() + query).Result;
            return serializer.Deserialize<IEnumerable<T>>(result);
        }

        public T GetById<T>(int id)
        {
            var result = client.GetStringAsync(RemoveDTO<T>() + "/" + id.ToString()).Result;
            return serializer.Deserialize<T>(result);
        }
    }
}
