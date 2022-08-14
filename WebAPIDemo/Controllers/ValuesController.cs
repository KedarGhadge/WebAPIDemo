using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        static List<string> strings = new List<string>
        {
            "value0","value1", "value2"
        };
        // GET api/values
        public IEnumerable<string> Get()
        {
            using (MySqlConnection dbConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connstring"].ConnectionString))
            {
                //MySqlConnection dbConn = new MySqlConnection();
                //dbConn.ConnectionString = "Server = 127.0.0.1; Port =3307; Database = webapi; Uid = root; Pwd = 123456;";
                MySqlCommand query = dbConn.CreateCommand();
                query.CommandText = "SELECT* FROM employee";
                dbConn.Open();
            MySqlDataAdapter sDa = new MySqlDataAdapter(query);
            DataTable dt = new DataTable("CharacterInfo");
            sDa.Fill(dt);
                //DataTable schemaTable = reader.GetSchemaTable();
                // Database work done here 
            }
            return strings;
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
