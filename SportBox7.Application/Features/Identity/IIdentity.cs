using SportBox7.Application.Common;
using SportBox7.Application.Features.Identity;
using SportBox7.Application.Features.Identity.Commands;
using SportBox7.Application.Features.Identity.Commands.LoginUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Identity
{
    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);
    }
}
