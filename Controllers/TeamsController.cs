using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsPlayersTaskWebAPI_MohammedElmorsy.Models;
using TeamsPlayersTaskWebAPI_MohammedElmorsy.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamsPlayersTaskWebAPI_MohammedElmorsy.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamRepository teamRepository;

        public TeamsController(TeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }
        // GET: api/<TeamController>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(teamRepository.GetAll());
        }

        //// GET api/<TeamController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<TeamController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<TeamController>/5
        [HttpPut]
        //  [ValidateAntiForgeryToken]
        public IActionResult Update(Team team)
        {
            if (ModelState.IsValid)
            {
                return Ok(teamRepository.Update(team));
            }
            return BadRequest(team);
        }

        //// DELETE api/<TeamController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
