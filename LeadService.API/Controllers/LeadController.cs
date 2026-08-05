using LeadService.Application.DTOs;
using LeadService.Application.DTOs.Lead;
using LeadService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeadService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadController : ControllerBase
{
    private readonly ILeadService _service;

    public LeadController(ILeadService service)
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
        var lead = await _service.GetByIdAsync(id);

        if (lead == null)
            return NotFound();

        return Ok(lead);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLeadDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateLeadDto dto)
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