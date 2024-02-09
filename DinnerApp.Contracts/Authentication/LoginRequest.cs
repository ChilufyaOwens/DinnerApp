namespace DinnerApp.Contracts.Authentication;

public record LoginRequest(
    string Username,
    string Password);
