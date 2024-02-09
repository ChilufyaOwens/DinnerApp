using Microsoft.VisualBasic;

namespace DinnerApp.Application.Services.Authentication;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Token);