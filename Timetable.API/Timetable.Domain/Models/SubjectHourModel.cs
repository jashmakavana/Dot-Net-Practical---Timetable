using System.ComponentModel.DataAnnotations;

namespace Timetable.Domain.Models;

public class SubjectHourModel
{
    [Required(ErrorMessage = "Subject name is required.")]
    public string Subject { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Subject hours must be a positive number.")]
    public int Hours { get; set; }
}
