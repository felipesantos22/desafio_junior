using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultationController : ControllerBase
{
    private readonly ConsultationRepository _consultationRepository;

    public ConsultationController(ConsultationRepository consultationRepository)
    {
        _consultationRepository = consultationRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Consultation>> Create([FromBody] Consultation consultation)
    {
        var newConsultation = await _consultationRepository.Create(consultation);
        return Ok(newConsultation);
    }

    [HttpGet]
    public async Task<ActionResult<List<Consultation>>> Index()
    {
        var consultations = await _consultationRepository.Index();
        return Ok(consultations);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Consultation>> Show(int id)
    {
        var consultation = await _consultationRepository.Show(id);
        if (consultation == null) return NotFound(new { message = "Consultation not found" });
        return Ok(consultation);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Consultation>> Update(int id, [FromBody] Consultation consultation)
    {
        var findConsultation = await _consultationRepository.Show(id);
        if (findConsultation == null) return NotFound(new { message = "Consultation not found" });
        var consultationUpdate = await _consultationRepository.Update(id, consultation);
        return Ok(consultationUpdate);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Consultation>> Destroy(int id)
    {
        var consultationId = await _consultationRepository.Show(id);
        if (consultationId == null) return NotFound(new { message = "Consultation not found" });
        var deleteConsultation = await _consultationRepository.Destroy(id);
        return Ok(new { message = "Consultation deleted" });
    }
}