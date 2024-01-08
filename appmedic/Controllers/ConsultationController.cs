using System.Security.Claims;
using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using appmedic.Services.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;

[ApiController]
[Route("api/consultation")]
public class ConsultationController : ControllerBase
{

    private readonly ConsultationRepository _consultationRepository;
    private readonly ValidateDateConsultation _dateConsultation;
    private readonly ValidateDoctorFk _validateDoctorFk;
    private readonly ValidatePatientFk _validatePatientFk;

    public ConsultationController(ConsultationRepository consultationRepository, ValidateDateConsultation dateConsultation, ValidateDoctorFk validateDoctorFk, ValidatePatientFk validatePatientFk)
    {
        _consultationRepository = consultationRepository;
        _dateConsultation = dateConsultation;
        _validateDoctorFk = validateDoctorFk;
        _validatePatientFk = validatePatientFk;
    }
    

    [Authorize(Roles = "Manager")]
    [HttpPost]
    public async Task<ActionResult<Consultation>> Create([FromBody] Consultation consultation)
    {
        var dateConsult = _dateConsultation.ConsultationHourExists(consultation.DateTime);
        if (dateConsult)
        {
            return BadRequest(new {message = "Hours unavailable, choose another time." });
        }

        var doctorFk = _validateDoctorFk.ExistsDoctorFk(consultation.DoctorId);
        
        if (!doctorFk)
        {
            return BadRequest(new { message = "Doctor not found" });
        }
        
        var patientFk = _validatePatientFk.ExistsPatientFk(consultation.PatienteId);
        
        if (!patientFk)
        {
            return BadRequest(new { message = "Patient not found" });
        }
        
        var newConsultation = await _consultationRepository.Create(consultation);
        return Ok(newConsultation);
    }
    

    [HttpGet]
    public async Task<ActionResult<List<Consultation>>> Index()
    {
        var consultations = await _consultationRepository.Index();
        return Ok(consultations);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Consultation>> Show(int id)
    {
        var consultation = await _consultationRepository.Show(id);
        if (consultation == null) return NotFound(new { message = "Consultation not found" });
        return Ok(consultation);
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult<Consultation>> Update(int id, [FromBody] Consultation consultation)
    {
        var findConsultation = await _consultationRepository.Show(id);
        if (findConsultation == null) return NotFound(new { message = "Consultation not found" });
        var consultationUpdate = await _consultationRepository.Update(id, consultation);
        return Ok(consultationUpdate);
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Consultation>> Destroy(int id)
    {
        var consultation = await _consultationRepository.Show(id);

        if (consultation == null) return NotFound(new { message = "Consultation not found" });
        
        
        var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        if (userRole != "Admin")
        {
            return NotFound(new { message = "You do not have permission to delete this consultation" });
        }

        var deleteConsultation = await _consultationRepository.Destroy(id);
        return Ok(new { message = "Consultation deleted" });
    }
}