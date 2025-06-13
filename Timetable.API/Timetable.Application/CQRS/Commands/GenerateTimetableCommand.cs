using MediatR;
using Timetable.Domain.Request;

namespace Timetable.Application.CQRS.Commands;

public class GenerateTimetableCommand : IRequest<List<List<string>>>
{
    public GenerateTimetableRequest GenerateTimetableRequest { get; set; }
    public GenerateTimetableCommand(GenerateTimetableRequest generateTimetableRequest)
    {
        GenerateTimetableRequest = generateTimetableRequest;
    }
}
