using EnquiryService.Application.DTOs.EnquiryFor;
using EnquiryService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnquiryService.API.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class EnquiryForController : ControllerBase
        {
            private readonly IEnquiryForService _service;

            public EnquiryForController(IEnquiryForService service)
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
                var enquiryFor = await _service.GetByIdAsync(id);

                if (enquiryFor == null)
                    return NotFound();

                return Ok(enquiryFor);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CreateEnquiryForDto dto)
            {
                return Ok(await _service.CreateAsync(dto));
            }

            [HttpPut]
            public async Task<IActionResult> Update(UpdateEnquiryForDto dto)
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

