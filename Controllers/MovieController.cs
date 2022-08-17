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
    public class MovieController : ControllerBase
    {
        SqlConnection conn = new SqlConnection("server=DESKTOP-RAC9J0E; database=IMDB; Integrated Security=true;");
        // GET: api/<MovieController>
        [HttpGet]
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Movie", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return Utility.ToJson(dt);
        }

        // POST api/<MovieController>
        [HttpPost("new")]
        public string Post([FromBody] Movie movie)
        {
            if (movie != null)
            {

                String query = "insert into Movie(movie_name, plot, producer_name, actor1_name, actor2_name, actor3_name, actor4_name, dor, poster) values(@movie_name, @plot, @producer_name, @actor1_name, @actor2_name, @actor3_name, @actor4_name, @dor, @poster);";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@movie_name", movie.movie_name);
                command.Parameters.AddWithValue("@plot", movie.plot);
                command.Parameters.AddWithValue("@producer_name", movie.producer_name);
                command.Parameters.AddWithValue("@actor1_name", movie.actor1_name);
                command.Parameters.AddWithValue("@actor2_name", movie.actor2_name);
                command.Parameters.AddWithValue("@actor3_name", movie.actor3_name);
                command.Parameters.AddWithValue("@actor4_name", movie.actor4_name);
                command.Parameters.AddWithValue("@dor", movie.dor);
                command.Parameters.AddWithValue("@poster", movie.poster);

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

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
