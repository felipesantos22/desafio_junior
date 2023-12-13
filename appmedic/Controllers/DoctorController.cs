using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using appmedic.Services.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;

[ApiController]
[Route("api/doctor")]
public class DoctorController : ControllerBase
{
    private readonly DoctorRepository _doctorRepository;
    private readonly ValidateCrm _validateCrm;

    public DoctorController(DoctorRepository doctorRepository, ValidateCrm validateCpfCrm)
    {
        _doctorRepository = doctorRepository;
        _validateCrm = validateCpfCrm;
    }


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Doctor>> Create([FromBody] Doctor doctor)
    {
        var crm = _validateCrm.CrmExists(doctor.CRM);
        if (crm)
        {
            return BadRequest(new {message = "Crm already registered." });
        }
        var newDoctor = await _doctorRepository.Create(doctor);
        return Ok(newDoctor);
    }


    [HttpGet]
    public async Task<ActionResult<List<Doctor>>> Index()
    {
        var doctors = await _doctorRepository.Index();
        return Ok(doctors);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> Show(int id)
    {
        var doctor = await _doctorRepository.Show(id);
        if (doctor == null) return NotFound(new { message = "Doctor not found" });
        return Ok(doctor);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Doctor>> Update(int id, [FromBody] Doctor doctor)
    {
        var updateDoctor = await _doctorRepository.Show(id);
        if (updateDoctor == null) return NotFound(new { message = "Doctor not found" });
        var doctorUpdate = await _doctorRepository.Update(id, doctor);
        return Ok(doctorUpdate);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Doctor>> Destroy(int id)
    {
        var doctorId = await _doctorRepository.Show(id);
        if (doctorId == null) return NotFound(new { message = "Doctor not found" });
        var deleteDoctor = await _doctorRepository.Destroy(id);
        return Ok(new { message = "Doctor deleted" });
    }

    //Dapper
    [HttpGet("search")]
    public async Task<ActionResult<List<Doctor>>> ShowName([FromQuery] string name)
    {
        var doctors = await _doctorRepository.ShowName(name);
        if (doctors == null) return NotFound(new { message = "Doctor not found" });
        return Ok(doctors);
    }
}