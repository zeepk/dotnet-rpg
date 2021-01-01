using rpg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using rpg.Services.CharacterService;
using System.Threading.Tasks;

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

        //introducing the service
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService){
            _characterService = characterService;
        }

        // return list of characters
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        // other options would be return BadRequest or 404 here

        // [HttpGet("GetSingle")]
        // public IActionResult GetSingle()
        // {
        //     return Ok(characters[0]);
        // }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        // add new character via POST request, info sent via body
        [HttpPost]
        public async Task<IActionResult> AddCharacter(Character newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

    }
}