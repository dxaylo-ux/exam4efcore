using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repositories;

public class AttendeeProfileRepository(AppDbContext appDbContext) : IAttendeeProfileRepository
{
    private AppDbContext context = appDbContext;

    public async Task<AttendeeProfile?> GetByAttendeeProfileIdAsync(int attendeeId)
    {
        return await context.AttendeeProfiles
        .Include(x => x.Attendee)
        .FirstOrDefaultAsync(x => x.AttendeeId == attendeeId);
    }

    public async Task<bool> AddAttendeeProfileAsync(AttendeeProfile profile)
    {
        context.AttendeeProfiles.Add(profile);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateAttendeeProfileAsync(AttendeeProfile profile)
    {
        var prf = await context.AttendeeProfiles.SingleOrDefaultAsync(x => x.AttendeeId == profile.AttendeeId);

        if (prf != null)
        {
            prf.DateOfBirth = profile.DateOfBirth;
            prf.City = profile.City;
            prf.Bio = profile.Bio;
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}