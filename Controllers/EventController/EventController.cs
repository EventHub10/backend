using backend.Core;
using backend.Services.EventService;
using backend.Services.EventService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.EventController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [DisableCors]
    public class EventController : ControllerBase
    {

        private readonly EventService _eventService;

        public EventController(EventService userService) 
        {
            _eventService = userService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
        {
            try 
            {
                var result = await _eventService.GetById(id, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _eventService.GetAll(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] EventDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _eventService.Insert(dto, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EventDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _eventService.Update(dto, cancellationToken);
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
                var result = await _eventService.Delete(id, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}