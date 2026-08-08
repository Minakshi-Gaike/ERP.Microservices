using LeadManagement.Application.DTOs;
using LeadManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadManagement.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class LeadsController : ControllerBase
        {
            private readonly ILeadService _leadService;

            public LeadsController(ILeadService leadService)
            {
                _leadService = leadService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _leadService.GetAllAsync();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _leadService.GetByIdAsync(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Insert(LeadDto leadDto)
            {
                var result = await _leadService.InsertAsync(leadDto);
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> Update(LeadDto leadDto)
            {
                var result = await _leadService.UpdateAsync(leadDto);
                return Ok(result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _leadService.DeleteAsync(id);
                return Ok(result);
            }

            [HttpPut("restore/{id}")]
            public async Task<IActionResult> Restore(int id)
            {
                var result = await _leadService.RestoreAsync(id);
                return Ok(result);
            }
        }
    }

