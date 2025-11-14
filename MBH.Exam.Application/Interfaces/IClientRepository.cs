using MBH.Exam.Domain.Entities;

namespace MBH.Exam.Application.Interfaces;

public interface IClientRepository : IRepository<Client>
{
    Task<Client?> GetByNameAsync(string name);
}
