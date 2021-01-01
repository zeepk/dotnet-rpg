using rpg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace rpg.Controllers
{
    [ApiController]
    // this enables API specific functions

    [Route("[controller]")]
    // this allows us to access it using postman/browser
    // entering "[controller]" just means it'll use the name, Character
    public class CharacterController : ControllerBase
    // to make a class into a controller, have Controller derive from ControllerBase
    // can also derive from Controller if you need views, but this is just an API
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character {Id = 1, Name = "Kennet"},
        };

        // return list of characters
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }
        // other options would be return BadRequest or 404 here

        // [HttpGet("GetSingle")]
        // public IActionResult GetSingle()
        // {
        //     return Ok(characters[0]);
        // }
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }

        // add new character via POST request, info sent via body
        [HttpPost]
        public IActionResult AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(characters);
        }

    }
}