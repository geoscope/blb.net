﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BLB.Api.Net.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // DELETE: api/v1/Categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/v1/Categories
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/v1/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/v1/Categories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/v1/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}