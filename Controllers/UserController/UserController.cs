using backend.Services.UserServices;
using backend.Services.UserServices.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;

        public UserController(UserService userService) 
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
        {
            try 
            {
                var result = await _userService.GetById(id, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.Insert(dto, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.Update(dto, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.Delete(id, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] string email, string senha, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.Login(email, senha, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

    }
}