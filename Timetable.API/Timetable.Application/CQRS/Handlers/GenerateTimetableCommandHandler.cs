using MediatR;
using Timetable.Application.CQRS.Commands;

namespace Timetable.Application.CQRS.Handlers;


public class GenerateTimetableCommandHandler : IRequestHandler<GenerateTimetableCommand, List<List<string>>>
{
    public Task<List<List<string>>> Handle(GenerateTimetableCommand request, CancellationToken cancellationToken)
    {
        int hoursPerWeek = request.GenerateTimetableRequest.WorkingDays * request.GenerateTimetableRequest.SubjectsPerDay;

        // check total hours per week is equal to (hours per day * working days)
        if (request.GenerateTimetableRequest.SubjectHours.Sum(a => a.Hours) != hoursPerWeek)
            throw new InvalidOperationException("Subject hours must equal total timetable slots.");

        List<List<string>> timeTable = new();

        for (int i = 0; i < request.GenerateTimetableRequest.WorkingDays; i++)
        {
            timeTable.Add(new List<string>());
        }

        int ind = 0;
        for (int i = 0; i < request.GenerateTimetableRequest.SubjectHours.Select(a => a.Subject).Count(); i++)
        {
            for (int j = 0; j < request.GenerateTimetableRequest.SubjectHours[i].Hours; j++)
            {
                if (ind > request.GenerateTimetableRequest.WorkingDays - 1)
                {
                    ind = 0;
                }
                var currList = timeTable.ElementAt(ind);
                currList.Add(request.GenerateTimetableRequest.SubjectHours[i].Subject);
                ind++;
            }
        }

        return Task.FromResult(timeTable);
    }
}
