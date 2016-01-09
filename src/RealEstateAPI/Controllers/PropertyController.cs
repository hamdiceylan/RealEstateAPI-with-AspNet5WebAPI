using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNet.Cors.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class PropertyController : Controller
    {
        string conStr = "Data Source=94.73.149.6;Initial Catalog=DB130717212225; User Id=USR130717212225; Password=Hamdi12345;";
        // GET: api/values
        [HttpGet]
        public IEnumerable<DataTable> Get()
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Property", connection))
                {
                    adapter.Fill(dt);
                }
            }
            return new DataTable[] { dt };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<DataTable> Get(int id)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand("select p.*,(u.Name +' '+u.Surname) as UserName,u.Phone,c.Name as CompanyName from Property p inner join Users u on u.Id = p.UserId inner join Company c on u.CompanyId= c.Id Where p.Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }
            return new DataTable[] { dt };
        }

        // GET api/values/5
        [HttpGet("{userId}")]
        public IEnumerable<DataTable> GetFromUserId(int userId)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand("Select * from Property Where UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", userId);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }
            return new DataTable[] { dt };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
