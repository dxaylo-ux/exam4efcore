using System.Net;
using Application.DTOs.TicketType;
using Application.Interfaces;
using Domain.Interface;
using Domain.Models;

namespace Application.Service;

public class TicketTypeService(ITicketTypeRepository repository) : ITicketTypeService
{
    private ITicketTypeRepository service = repository;

    public async Task<ApiResponse<List<TicketTypeDto>>> GetAllTicketTypeAsync()
    {
        var ticketTypes = await service.GetAllTicketTypeAsync();
        var result = ticketTypes.Select(x => new TicketTypeDto
        {
            Id = x.Id,
            EventId = x.EventId,
            Name = x.Name,
            Price = x.Price,
            Quantity = x.Quantity,
            SoldCount = x.SoldCount

        }).ToList();

        return new ApiResponse<List<TicketTypeDto>>(HttpStatusCode.OK,"List of ticket types",result);
    }

    public async Task<ApiResponse<TicketTypeDto>> GetTicketTypeByIdAsync(int id)
    {
        var ticketType = await service.GetTicketTypeByIdAsync(id);

        if (ticketType == null)
        {
            return new ApiResponse<TicketTypeDto>(HttpStatusCode.NotFound,"Ticket type not found",null!);
        }

        var result = new TicketTypeDto
        {
            Id = ticketType.Id,
            EventId = ticketType.EventId,
            Name = ticketType.Name,
            Price = ticketType.Price,
            Quantity = ticketType.Quantity,
            SoldCount = ticketType.SoldCount
        };

        return new ApiResponse<TicketTypeDto>(HttpStatusCode.OK,"Ticket type by id",result);
    }

    public async Task<ApiResponse<bool>> AddTicketTypeAsync(
        TicketTypeCreateDto ticketType)
    {
        var tkt = new TicketType
        {
            EventId = ticketType.EventId,
            Name = ticketType.Name,
            Price = ticketType.Price,
            Quantity = ticketType.Quantity,
            SoldCount = 0
        };

        var result = await service.AddTicketTypeAsync(tkt);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Ticket type added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Ticket type not added",result);
    }

    public async Task<ApiResponse<bool>> UpdateTicketTypeAsync(int id,TicketTypeUpdateDto ticketType)
    {
        var tkt = new TicketType
        {
            Id = id,
            Name = ticketType.Name,
            Price = ticketType.Price,
            Quantity = ticketType.Quantity
        };

        var result = await service.UpdateTicketTypeAsync(tkt);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Ticket type updated",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Ticket type cannot be updated",result);
    }

    public async Task<ApiResponse<bool>> DeleteTicketTypeAsync(int id)
    {
        var result = await service.DeleteTicketTypeAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Ticket type deleted",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Ticket type cannot be deleted",result);
    }

}