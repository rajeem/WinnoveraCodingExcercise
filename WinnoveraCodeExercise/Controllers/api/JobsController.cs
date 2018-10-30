using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WinnoveraCodeExercise.Controllers.api
{
    public class Job
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string company { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Job>> GetAll()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://jobs.github.com");

            var response = await client.GetAsync("positions.json");
            return await response.Content.ReadAsAsync<List<Job>>();
        }
    }
}