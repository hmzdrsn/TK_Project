namespace TK_Project.Application.Interfaces.Repositories.Role
{
    public interface IRoleWriteRepository : IWriteRepository<Domain.Entities.Role>
    {
        Task<Domain.Entities.User> AssignRole(int customerID,List<int> roleIDList);
    }
}
