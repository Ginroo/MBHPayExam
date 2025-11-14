using MBH.Exam.Domain.Entities;

namespace MBH.Exam.Application.Interfaces;

public interface IClientSessionRepository : IRepository<ClientSession>
{
    Task<IEnumerable<ClientSession>> GetSessionsByClientNameAsync(string clientName);
    Task<IEnumerable<ClientSession>> GetSessionsByDateRangeAsync(DateTime startDate, DateTime endDate);
}
