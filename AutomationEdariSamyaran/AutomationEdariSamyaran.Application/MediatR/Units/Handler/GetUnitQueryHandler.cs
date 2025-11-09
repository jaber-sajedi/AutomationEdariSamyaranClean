using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Application.MediatR.Units.Queries;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomationEdariSamyaran.Application.MediatR.Units.Handler
{
    public class GetAllUnitsQueryHandler : IRequestHandler<GetAllUnitsQuery, List<UnitDto>>
    {
        private readonly AppDbContext _context;

        public GetAllUnitsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UnitDto>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Units
                                       .AsNoTracking()
                                       .Select(u => new UnitDto
                                       {
                                           Id = u.Id,
                                           UnitName = u.UnitName,
                                       })
                                       .ToListAsync(cancellationToken);

            return result;
        }
    }
}
