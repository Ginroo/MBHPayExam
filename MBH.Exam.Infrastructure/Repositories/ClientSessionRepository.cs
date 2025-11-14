using MBH.Exam.Application.Interfaces;
using MBH.Exam.Domain.Entities;
using MBH.Exam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MBH.Exam.Infrastructure.Repositories;

public class ClientSessionRepository : Repository<ClientSession>, IClientSessionRepository
{
    public ClientSessionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ClientSession>> GetSessionsByClientNameAsync(string clientName)
    {
        if (string.IsNullOrWhiteSpace(clientName))
            throw new ArgumentException("Client name cannot be null or empty", nameof(clientName));

        return await _context.Set<ClientSession>()
            .Where(s => s.ClientName.ToLower().Contains(clientName.ToLower()))
            .OrderByDescending(s => s.SessionDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientSession>> GetSessionsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Set<ClientSession>()
            .Where(s => s.SessionDate >= startDate && s.SessionDate <= endDate)
            .OrderByDescending(s => s.SessionDate)
            .ToListAsync();
    }

    public override async Task<IEnumerable<ClientSession>> GetAllAsync()
    {
        return await _context.Set<ClientSession>()
            .OrderByDescending(s => s.SessionDate)
            .ToListAsync();
    }
}
