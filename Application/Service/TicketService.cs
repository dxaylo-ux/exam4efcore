using System.Net;
using Application.DTOs.Ticket;
using Application.Interfaces;
using Domain.Interface;
using Domain.Models;

namespace Application.Service;

public class TicketService(ITicketRepository repository) : ITicketService
{
    private ITicketRepository service = repository;

    public async Task<ApiResponse<TicketDto>> GetTicketByIdAsync(int id)
    {
        var ticket = await service.GetTicketByIdAsync(id);

        if (ticket == null)
        {
            return new ApiResponse<TicketDto>(HttpStatusCode.NotFound,"Ticket not found",null!);
        }

        var result = new TicketDto
        {
            Id = ticket.Id,
            OrderId = ticket.OrderId,
            TicketTypeId = ticket.TicketTypeId,
            AttendeeId = ticket.AttendeeId,
            Code = ticket.Code,
            Price = ticket.Price,
            PurchasedAt = ticket.PurchasedAt,
            IsCheckedIn = ticket.IsCheckedIn,
            CheckedInAt = ticket.CheckedInAt
        };

        return new ApiResponse<TicketDto>(HttpStatusCode.OK,"Ticket by id",result);
    }

    public async Task<ApiResponse<TicketDto>> GetTicketByCodeAsync(Guid code)
    {
        var ticket = await service.GetTicketByCodeAsync(code);

        if (ticket == null)
        {
            return new ApiResponse<TicketDto>(HttpStatusCode.NotFound,"Ticket not found",null!);
        }

        var result = new TicketDto
        {
            Id = ticket.Id,
            OrderId = ticket.OrderId,
            TicketTypeId = ticket.TicketTypeId,
            AttendeeId = ticket.AttendeeId,
            Code = ticket.Code,
            Price = ticket.Price,
            PurchasedAt = ticket.PurchasedAt,
            IsCheckedIn = ticket.IsCheckedIn,
            CheckedInAt = ticket.CheckedInAt
        };

        return new ApiResponse<TicketDto>(HttpStatusCode.OK,"Ticket by code",result);
    }

    public async Task<ApiResponse<List<TicketDto>>> GetTicketsByAttendeeIdAsync(int attendeeId)
    {
        var tickets = await service.GetTicketsByAttendeeIdAsync(attendeeId);
        var result = tickets.Select(x => new TicketDto
        {
            Id = x.Id,
            OrderId = x.OrderId,
            TicketTypeId = x.TicketTypeId,
            AttendeeId = x.AttendeeId,
            Code = x.Code,
            Price = x.Price,
            PurchasedAt = x.PurchasedAt,
            IsCheckedIn = x.IsCheckedIn,
            CheckedInAt = x.CheckedInAt

        }).ToList();

        return new ApiResponse<List<TicketDto>>(HttpStatusCode.OK,"Attendee tickets",result);
    }

    public async Task<ApiResponse<bool>> AddTicketAsync(TicketCreateDto ticket)
    {
        var tkt = new Ticket
        {
            OrderId = ticket.OrderId,
            TicketTypeId = ticket.TicketTypeId,
            AttendeeId = ticket.AttendeeId,
            Price = ticket.Price,
            Code = Guid.NewGuid(),
            PurchasedAt = DateTime.UtcNow,
            IsCheckedIn = false
        };

        var result = await service.AddTicketAsync(tkt);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Ticket added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Ticket not added",result);
    }

    public async Task<ApiResponse<bool>> UpdateTicketAsync(int id,TicketUpdateDto ticket)
    {
        var tkt = new Ticket
        {
            Id = id,
            OrderId = ticket.OrderId,
            TicketTypeId = ticket.TicketTypeId,
            AttendeeId = ticket.AttendeeId,
            Price = ticket.Price,
            IsCheckedIn = ticket.IsCheckedIn,
            CheckedInAt = ticket.CheckedInAt
        };

        var result = await service.UpdateTicketAsync(tkt);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Ticket updated",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Ticket cannot be updated",result);
    }
}