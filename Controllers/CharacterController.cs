using System.Collections.Generic;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController: ControllerBase
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Name = "Sam"}
        };
        
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }

        public IActionResult GetSingle()
        {
            return Ok(characters[0]);
        }
    }
}