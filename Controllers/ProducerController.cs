using ImdbAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImdbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        SqlConnection conn = new SqlConnection("server=DESKTOP-RAC9J0E; database=IMDB; Integrated Security=true;");
        // GET: api/<ProducerController>
        [HttpGet]
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Producer", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Utility.ToJson(dt);
            }
            else
            {
                return "No data found";
            }
        }

        // POST api/<ProducerController>
        [HttpPost("new")]
        public string NewProducer([FromBody] Producer producer)
        {
            if (producer != null)
            {

                String query = "insert into Producer(producer_name, company, bio, dob, gender) values(@producer_name, @company, @bio, @dob, @gender); ";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@producer_name", producer.producer_name);
                command.Parameters.AddWithValue("@company", producer.company);
                command.Parameters.AddWithValue("@bio", producer.bio);
                command.Parameters.AddWithValue("@gender", producer.gender);
                command.Parameters.AddWithValue("@dob", producer.dob);

                conn.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                    return "Success!";
                // Check Error
                else
                    return "Error inserting data into Database!";
            }
            else
                return "Error inserting data into Database!";
        }

    }
}
