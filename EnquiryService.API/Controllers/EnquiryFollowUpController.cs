using EnquiryService.Application.DTOs.EnquiryFollowUp;
using EnquiryService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace EnquiryService.API.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class EnquiryFollowUpController : ControllerBase
        {
            private readonly IEnquiryFollowUpService _service;

            public EnquiryFollowUpController(IEnquiryFollowUpService service)
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
                var followUp = await _service.GetByIdAsync(id);

                if (followUp == null)
                    return NotFound();

                return Ok(followUp);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CreateEnquiryFollowUpDto dto)
            {
                return Ok(await _service.CreateAsync(dto));
            }

            [HttpPut]
            public async Task<IActionResult> Update(UpdateEnquiryFollowUpDto dto)
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

