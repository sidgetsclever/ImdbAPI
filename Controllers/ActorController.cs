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
    public class ActorController : ControllerBase
    {
        SqlConnection conn = new SqlConnection("server=DESKTOP-RAC9J0E; database=IMDB; Integrated Security=true;");
        // GET: api/<ActorController>
        [HttpGet]
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Actor", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //return JsonConvert.SerializeObject(dt);
                return Utility.ToJson(dt);
            }
            else
            {
                return "No data found";
            }
        }


        // POST api/<ActorController>
        [HttpPost("new")]
        public string NewActor([FromBody] Actor newActor)
        {
            if (newActor != null)
            {

                String query = "insert into Actor (actor_name, bio, dob, gender) values(@actor_name, @bio, @dob, @gender); ";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@actor_name", newActor.actor_name);
                command.Parameters.AddWithValue("@bio", newActor.bio);
                command.Parameters.AddWithValue("@gender", newActor.gender);
                command.Parameters.AddWithValue("@dob", newActor.dob);

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
