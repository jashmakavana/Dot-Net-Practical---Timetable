using System.ComponentModel.DataAnnotations;
using Timetable.Domain.Models;

namespace Timetable.Domain.Request;

public class GenerateTimetableRequest
{
    [Range(1, 7, ErrorMessage = "Working days must be between 1 and 7.")]
    public int WorkingDays { get; set; }

    [Range(1, 8, ErrorMessage = "Subjects per day must be a positive number less than 9.")]
    public int SubjectsPerDay { get; set; }

    [MinLength(1, ErrorMessage = "At least one subject must be provided.")]
    public List<SubjectHourModel> SubjectHours { get; set; } = new();
}
