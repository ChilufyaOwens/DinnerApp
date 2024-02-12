using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Entities;

namespace DinnerApp.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = []; 
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
 
    public void Add(User user)
    {
       _users.Add(user); 
    }
}