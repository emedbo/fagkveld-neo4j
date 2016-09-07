using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Newtonsoft.Json;

namespace FagkveldNeo4J.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private GraphClient _client;

        public ValuesController()
        {
            _client = new Neo4jClient.GraphClient(new Uri("http://fagkveld:s6xM2G7oSZOTXaCW2qWk@fagkveld.sb02.stations.graphenedb.com:24789/db/data/"), "fagkveld", "s6xM2G7oSZOTXaCW2qWk");
            _client.Connect();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stuff = _client.Cypher.Match("(p:Person)")
                .Return(p => p.As<Person>()).Results;
            return Ok(stuff);
        }
    }
    
    public class Person
    {
        
        public string name { get; set; }
        public string occupation { get; set; }
    }
}
