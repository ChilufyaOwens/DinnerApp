﻿using DinnerApp.Domain.User;

namespace DinnerApp.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);

