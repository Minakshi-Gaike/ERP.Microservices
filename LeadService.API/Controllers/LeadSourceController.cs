using LeadService.Application.DTOs.LeadSource;
using LeadService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace LeadService.API.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class LeadSourceController : ControllerBase
        {
            private readonly ILeadSourceService _service;

            public LeadSourceController(ILeadSourceService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _service.GetAllAsync());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var leadSource = await _service.GetByIdAsync(id);

                if (leadSource == null)
                    return NotFound();

                return Ok(leadSource);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CreateLeadSourceDto dto)
            {
                return Ok(await _service.CreateAsync(dto));
            }

            [HttpPut]
            public async Task<IActionResult> Update(UpdateLeadSourceDto dto)
            {
                return Ok(await _service.UpdateAsync(dto));
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                return Ok(await _service.DeleteAsync(id));
            }

            [HttpPut("restore/{id}")]
            public async Task<IActionResult> Restore(int id)
            {
                return Ok(await _service.RestoreAsync(id));
            }
        }
    }

