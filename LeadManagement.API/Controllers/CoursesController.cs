using LeadManagement.Application.DTOs;
using LeadManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace LeadManagement.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CoursesController : ControllerBase
        {
            private readonly ICourseService _courseService;

            public CoursesController(ICourseService courseService)
            {
                _courseService = courseService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _courseService.GetAllAsync();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _courseService.GetByIdAsync(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Insert(CourseDto courseDto)
            {
                var result = await _courseService.InsertAsync(courseDto);
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> Update(CourseDto courseDto)
            {
                var result = await _courseService.UpdateAsync(courseDto);
                return Ok(result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _courseService.DeleteAsync(id);
                return Ok(result);
            }

            [HttpPut("restore/{id}")]
            public async Task<IActionResult> Restore(int id)
            {
                var result = await _courseService.RestoreAsync(id);
                return Ok(result);
            }
        }
    }

