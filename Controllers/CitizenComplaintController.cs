using OGServer.Models;
using OGServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace OGServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CitizenComplaintController : ControllerBase
{
    public CitizenComplaintController()
    {
    }

    [HttpPost]
    public IActionResult Create(CitizenComplaint complaint)
    {
        CitizenComplaintService.Add(complaint);
        return CreatedAtAction(nameof(Get), new { id = complaint.Id }, complaint);
    }

    [HttpGet]
    public ActionResult<List<CitizenComplaint>> GetAll()
    {
        return CitizenComplaintService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<CitizenComplaint> Get(int id)
    {
        CitizenComplaint? citizenComplaint = CitizenComplaintService.GetById(id);

        if(citizenComplaint == null)
        {
            return NotFound();
        }

        return Ok(citizenComplaint);
    }

    [HttpPut("{id}")]
    public ActionResult<CitizenComplaint> Update(int id, CitizenComplaint complaint)
    {
        CitizenComplaint? citizenComplaint = CitizenComplaintService.GetById(id);
        if(citizenComplaint == null)
        {
            return NotFound();
        }

        CitizenComplaint updatedComplaint = CitizenComplaintService.Update(complaint);

        return Ok(updatedComplaint);
    }
}