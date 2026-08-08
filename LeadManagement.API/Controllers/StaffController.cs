using LeadManagement.Application.DTOs;
using LeadManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace LeadManagement.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class StaffController : ControllerBase
        {
            private readonly IStaffService _staffService;

            public StaffController(IStaffService staffService)
            {
                _staffService = staffService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _staffService.GetAllAsync();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _staffService.GetByIdAsync(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Insert(StaffDto staffDto)
            {
                var result = await _staffService.InsertAsync(staffDto);
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> Update(StaffDto staffDto)
            {
                var result = await _staffService.UpdateAsync(staffDto);
                return Ok(result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _staffService.DeleteAsync(id);
                return Ok(result);
            }

            [HttpPut("restore/{id}")]
            public async Task<IActionResult> Restore(int id)
            {
                var result = await _staffService.RestoreAsync(id);
                return Ok(result);
            }
        }
    }

