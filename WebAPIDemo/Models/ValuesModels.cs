using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class ValuesModels
    {
        static List<string> strings = new List<string>();
        public List<string> GetUsers()
        {

            using (MySqlConnection dbConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connstring"].ConnectionString))
            {
                MySqlCommand query = dbConn.CreateCommand();
                query.CommandText = "SELECT * FROM employee";
                dbConn.Open();
                MySqlDataAdapter sDa = new MySqlDataAdapter(query);
                DataTable dt = new DataTable("CharacterInfo");
                sDa.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    strings.Add(dr["EmployeeName"].ToString());
                }
                //DataTable schemaTable = reader.GetSchemaTable();
                // Database work done here 

                return strings;
            }
        }
    }
}