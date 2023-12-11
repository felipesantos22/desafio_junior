using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly PatientRepository _patientRepository;

    public PatientController(PatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> Create([FromBody] Patient patient)
    {
        var newPatient = await _patientRepository.Create(patient);
        return Ok(newPatient);
    }

    [HttpGet]
    public async Task<ActionResult<List<Patient>>> Index()
    {
        var patients = await _patientRepository.Index();
        return Ok(patients);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> Show(int id)
    {
        var patient = await _patientRepository.Show(id);
        if (patient == null) return NotFound(new { message = "Patient not found" });
        return Ok(patient);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Patient>> Update(int id, [FromBody] Patient patient)
    {
        var updatePatient = await _patientRepository.Show(id);
        if (updatePatient == null) return NotFound(new { message = "Patient not found" });
        var patientUpdate = await _patientRepository.Update(id, patient);
        return Ok(patientUpdate);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Patient>> Destroy(int id)
    {
        var patientId = await _patientRepository.Show(id);
        if (patientId == null) return NotFound(new { message = "Patient not found" });
        var deletePatient = await _patientRepository.Destroy(id);
        return Ok(new { message = "Patient deleted" });
    }
}