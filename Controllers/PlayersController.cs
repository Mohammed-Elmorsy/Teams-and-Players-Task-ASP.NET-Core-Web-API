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
    public class PlayersController : ControllerBase
    {
        PlayerRepository playerRepository;

        public PlayersController(PlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }
        // GET: api/<PlayerController>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(playerRepository.GetAll());
        }

        //// GET api/<PlayerController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PlayerController>
        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PlayerController>/5
        [HttpPut]
        public IActionResult Update(Player player)
        {
            if (ModelState.IsValid)
            {
                return Ok(playerRepository.Update(player));
            }
            return BadRequest(player);
        }

        //// DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(playerRepository.Remove(id));
        }
    }
}
