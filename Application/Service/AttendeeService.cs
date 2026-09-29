using System.Net;
using Application.DTOs.Attendee;
using Domain.Interface;
using Domain.Models;
using Application.Interfaces;


namespace Application.Service;

public class AttendeeService(IAttendeeRepository repository) : IAttendeeService
{
    private IAttendeeRepository service = repository;

    public async Task<ApiResponse<List<AttendeeDto>>> GetAllAttendeeAsync()
    {
        var attendees = await service.GetAllAttendeeAsync();
        var result = attendees.Select(x => new AttendeeDto
        {
            Id = x.Id,
            FullName = x.FullName,
            Email = x.Email,
            RegisteredAt = x.RegisteredAt

        }).ToList();

        return new ApiResponse<List<AttendeeDto>>(HttpStatusCode.OK,"List of attendees",result);
    }

    public async Task<ApiResponse<AttendeeDto>> GetAttendeeByIdAsync(int id)
    {
        var attendee = await service.GetAttendeeByIdAsync(id);

        if (attendee == null)
        {
            return new ApiResponse<AttendeeDto>(HttpStatusCode.NotFound,"Attendee not found",null!);
        }

        var result = new AttendeeDto
        {
            Id = attendee.Id,
            FullName = attendee.FullName,
            Email = attendee.Email,
            RegisteredAt = attendee.RegisteredAt
        };

        return new ApiResponse<AttendeeDto>(HttpStatusCode.OK,"Attendee by id",result);
    }

    public async Task<ApiResponse<bool>> AddAttendeeAsync(AttendeeCreateDto attendee)
    {
        var att = new Attendee
        {
            FullName = attendee.FullName,
            Email = attendee.Email
        };

        var result = await service.AddAttendeeAsync(att);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Attendee added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Attendee not added",result);
    }

    public async Task<ApiResponse<bool>> UpdateAttendeeAsync(int id,UpdateAttendeeDto attendee)
    {
        var att = new Attendee
        {
            Id = id,
            FullName = attendee.FullName,
            Email = attendee.Email,
            RegisteredAt = attendee.RegisteredAt
        };

        var result = await service.UpdateAttendeeAsync(att);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Attendee updated",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Attendee cannot be updated",result);
    }

    public async Task<ApiResponse<bool>> DeleteAttendeeAsync(int id)
    {
        var result = await service.DeleteAttendeeAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Attendee deleted",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Attendee cannot be deleted",result);
    }

    public async Task<ApiResponse<bool>> ExistsAsync(int id)
    {
        var result = await service.ExistsAsync(id);
        return result
        
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Attendee exists",result)
        : new ApiResponse<bool>(HttpStatusCode.NotFound,"Attendee not found",result);
    }
}