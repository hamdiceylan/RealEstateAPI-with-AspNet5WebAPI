﻿using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNet.Cors.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class CompanyController : Controller
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
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Company", connection))
                {
                    adapter.Fill(dt);
                }
            }
            return new DataTable[] { dt };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
