using System.Net;
using Application.DTOs.Organizer;
using Domain.Interface;
using Domain.Models;
using Application.Interfaces;

namespace Application.Service;

public class OrganizerService(IOrganizerRepository repository) : IOrganizerService
{
    private IOrganizerRepository service = repository;

    public async Task<ApiResponse<List<OrganizerDto>>> GetAllOrganizerAsync()
    {
        var organizers = await service.GetAllOrganizerAsync();
        var result = organizers.Select(x => new OrganizerDto
        {
            Id = x.Id,
            CompanyName = x.CompanyName,
            ContactEmail = x.ContactEmail,
            Phone = x.Phone

        }).ToList();

        return new ApiResponse<List<OrganizerDto>>(HttpStatusCode.OK,"List of organizers",result);
    }

    public async Task<ApiResponse<OrganizerDto>> GetOrganizerByIdAsync(int id)
    {
        var organizer = await service.GetOrganizerByIdAsync(id);

        if (organizer == null)
        {
            return new ApiResponse<OrganizerDto>(
                HttpStatusCode.NotFound,
                "Organizer not found",
                null!);
        }

        var result = new OrganizerDto
        {
            Id = organizer.Id,
            CompanyName = organizer.CompanyName,
            ContactEmail = organizer.ContactEmail,
            Phone = organizer.Phone
        };

        return new ApiResponse<OrganizerDto>(HttpStatusCode.OK,"Organizer by id",result);
    }

    public async Task<ApiResponse<bool>> AddOrganizerAsync(OrganizerCreateDto organizer)
    {
        var org = new Organizer
        {
            CompanyName = organizer.CompanyName,
            ContactEmail = organizer.ContactEmail,
            Phone = organizer.Phone
        };

        var result = await service.AddOrganizerAsync(org);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Organizer added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Organizer not added",result);
    }

    public async Task<ApiResponse<bool>> UpdateOrganizerAsync(int id,OrganizerUpdateDto organizer)
    {
        var org = new Organizer
        {
            Id = id,
            CompanyName = organizer.CompanyName,
            ContactEmail = organizer.ContactEmail,
            Phone = organizer.Phone
        };

        var result = await service.UpdateOrganizerAsync(org);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Organizer updated",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Organizer cannot be updated",result);
    }

    public async Task<ApiResponse<bool>> DeleteOrganizerAsync(int id)
    {
        var result = await service.DeleteOrganizerAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Organizer deleted",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Organizer cannot be deleted",result);
    }

    public async Task<ApiResponse<bool>> ExistsAsync(int id)
    {
        var result = await service.ExistsAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Organizer exists",result)
        : new ApiResponse<bool>(HttpStatusCode.NotFound,"Organizer not found",result);
    }
}