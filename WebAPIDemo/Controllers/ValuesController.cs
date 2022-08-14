using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        static List<string> strings = new List<string>
        {
            "value0","value1", "value2"
        };
        private static ValuesModels _users = new ValuesModels();
        private static List<string> myList = _users.GetUsers();
        // GET api/values
        public IEnumerable<string> Get()
        {
            //FetchList();
            
            //foreach (DataRow dr in dt.Rows)
            //{
            //    strings.Add(dr["EmployeeName"].ToString());
            //}
            return myList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return strings[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            strings.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            strings[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            strings.RemoveAt(id);
        }

        
    }
}
