namespace SportBox7.Infrastructure.Identity
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Features.Identity;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Identity.Commands;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using SportBox7.Application.Features.Identity.Queries.AllUsers;
    using SportBox7.Application.Features.Identity.Queries.UserDetails;
    using SportBox7.Domain.Factories.Editors;

    public class IdentityService : IIdentity
    {
        private const string InvalidLoginErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IEditorFactory editorFactory;
        private readonly IEditorRepository editorRepository;
        private readonly IMapper mapper;


        public IdentityService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEditorFactory editorFactory,
            IEditorRepository editorRepository,
            IMapper mapper)
        {
            this.editorFactory = editorFactory;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.editorRepository = editorRepository;
            this.mapper = mapper;
        }

        public async Task<List<SimpleUserListingModel>>GetAllSimpleUsers()
            => await Task.Run(() => this.mapper.ProjectTo<SimpleUserListingModel>(userManager.Users.Where(x => x.Editor != null).Select(u => u.Editor)).ToList());

        public async Task<UserDetailsOutputModel> GetUserDetailsByEditorId(int id)
        {
            var tempUser = userManager.Users.Where(x => x.Editor != null).Where(u => u.Editor!.Id == id).FirstOrDefault();
            var resultUser = this.mapper.Map<UserDetailsOutputModel>(tempUser);
            if (tempUser != null)
            {
                var editor = await editorRepository.FindByUser(tempUser.Id);
                resultUser.FirstName = editor.FirstName;
                resultUser.LastName = editor.LastName;

                return resultUser;
            }
            return new UserDetailsOutputModel();
        }

        public async Task<Result<LoginSuccessModel>> Login(UserInputModel userInput)
        {
            if (userInput.Email == null)
            {
                return InvalidLoginErrorMessage;
            }
            var user = await this.userManager.FindByEmailAsync(userInput.Email);

            if (user == null)
            {
                return InvalidLoginErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidLoginErrorMessage;
            }

            if (await userManager.IsInRoleAsync(user, "Admin"))
            {
                if (user.Editor == null)
                {
                    var editor = editorFactory.WithFirstName("Lyubomir")
                        .WithLastName("Kavdansky")
                        .Build();

                    user.BecomeEditor(editor);
                    await editorRepository.Save(editor);
                }
            }

            await this.signInManager.SignInAsync(user, false);

            return new LoginSuccessModel(user.Id, user.Email);
        }

        public async Task<Result> Logout()
        {
            await this.signInManager.SignOutAsync();
            return Result.Success;
        }

        public async Task<Result<IUser>> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email);
            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);
            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IUser>.SuccessWith(user)
                : Result<IUser>.Failure(errors);
        }  
    }
}
