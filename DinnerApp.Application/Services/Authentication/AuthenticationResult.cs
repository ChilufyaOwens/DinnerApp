using DinnerApp.Domain.Entities;
using Microsoft.VisualBasic;

namespace DinnerApp.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);