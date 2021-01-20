﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Identity.Commands
{
    public abstract class UserInputModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}