using MBH.Exam.Application.Interfaces;
using MBH.Exam.Domain.Entities;
using MBH.Exam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MBH.Exam.Infrastructure.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Client?> GetByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Client name cannot be null or empty", nameof(name));

        return await _context.Set<Client>()
            .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    }
}
