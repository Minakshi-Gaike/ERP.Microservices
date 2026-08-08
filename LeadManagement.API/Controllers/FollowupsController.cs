using LeadManagement.Application.DTOs;
using LeadManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace LeadManagement.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class FollowupsController : ControllerBase
        {
            private readonly IFollowupService _followupService;

            public FollowupsController(IFollowupService followupService)
            {
                _followupService = followupService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _followupService.GetAllAsync();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _followupService.GetByIdAsync(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Insert(FollowupDto followupDto)
            {
                var result = await _followupService.InsertAsync(followupDto);
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> Update(FollowupDto followupDto)
            {
                var result = await _followupService.UpdateAsync(followupDto);
                return Ok(result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _followupService.DeleteAsync(id);
                return Ok(result);
            }

            [HttpPut("restore/{id}")]
            public async Task<IActionResult> Restore(int id)
            {
                var result = await _followupService.RestoreAsync(id);
                return Ok(result);
            }
        }
    }

