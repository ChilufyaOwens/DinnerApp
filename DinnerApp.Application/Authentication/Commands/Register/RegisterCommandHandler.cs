using DinnerApp.Application.Authentication.Common;
using DinnerApp.Application.Common.Interfaces.Authentication;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Common.Errors;
using DinnerApp.Domain.User;
using ErrorOr;
using MediatR;


namespace DinnerApp.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler(
        IJwtTokenGenerator tokenGenerator, 
        IUserRepository userRepository) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // Validate user doesn't exist 
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                UserName = command.UserName,
                Password = command.Password
            };

            _userRepository.Add(user);

            var token =_tokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user, token);
        }
    }
}
