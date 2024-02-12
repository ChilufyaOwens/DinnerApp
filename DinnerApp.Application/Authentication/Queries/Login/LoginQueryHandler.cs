using DinnerApp.Application.Authentication.Common;
using DinnerApp.Application.Common.Interfaces.Authentication;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace DinnerApp.Application.Authentication.Queries.Login;

public class LoginQueryHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository) 
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(query.Email) is not { } user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        if (user.Password != query.Password  )
        {
            return Errors.Authentication.InvalidCredential;
        }

        var token = _tokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}
