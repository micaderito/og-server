using OGServer.Models;

namespace OGServer.Services;

public static class CitizenComplaintService
{
    static List<CitizenComplaint> Complaints { get; }
    static int nextId = 4;
    static CitizenComplaintService()
    {
        Complaints = new List<CitizenComplaint>
        {
            new CitizenComplaint { Id = 1, Complaint = "Pothole" },
            new CitizenComplaint { Id = 2, Complaint = "Leaky Hydrant" },
            new CitizenComplaint { Id = 3, Complaint = "Dog Barking" }
        };
    }

    public static void Add(CitizenComplaint complaint)
    {
        complaint.Id = nextId++;
        Complaints.Add(complaint);
    }

    public static List<CitizenComplaint> GetAll()
    {
        return Complaints;
    }

    public static CitizenComplaint? GetById(int id)
    {
        return Complaints.Find(x => x.Id == id);
    }

    public static CitizenComplaint? Update(CitizenComplaint updatedComplaint)
    {
        CitizenComplaint? citizenComplaint = GetById(updatedComplaint.Id);

        if (citizenComplaint != null)
        {
            citizenComplaint.Complaint = updatedComplaint.Complaint;
            citizenComplaint.Notes = updatedComplaint.Notes;
        }

        return citizenComplaint;
    }
}