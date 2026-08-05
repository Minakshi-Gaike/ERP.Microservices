using CollegeLeadService.Application.DTOs.CollegeLead;
using CollegeLeadService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CollegeLeadService.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class CollegeLeadController : ControllerBase
    {
        private readonly ICollegeLeadService _service;

        public CollegeLeadController(ICollegeLeadService service)
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
            var collegeLead = await _service.GetByIdAsync(id);

            if (collegeLead == null)
                return NotFound();

            return Ok(collegeLead);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollegeLeadDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCollegeLeadDto dto)
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

