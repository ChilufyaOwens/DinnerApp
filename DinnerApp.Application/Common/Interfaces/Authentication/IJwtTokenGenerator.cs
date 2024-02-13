using DinnerApp.Domain.User;

namespace DinnerApp.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}