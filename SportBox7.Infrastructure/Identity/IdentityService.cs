namespace SportBox7.Infrastructure.Identity
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Features.Identity;
    using Microsoft.AspNetCore.Identity;
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Identity.Commands;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using SportBox7.Application.Features.Identity.Queries.AllUsers;
    using SportBox7.Domain.Factories.Editors;

    public class IdentityService : IIdentity
    {
        private const string InvalidLoginErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IEditorFactory editorFactory;
        private readonly IEditorRepository editorRepository;


        public IdentityService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEditorFactory editorFactory,
            IEditorRepository editorRepository)
        {
            this.editorFactory = editorFactory;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.editorRepository = editorRepository;
        }

        public Task<List<SimpleUserListingModel>>GetAllSimpleUsers()
        {
            var editors = userManager.Users.Where(x => x.Editor  != null).Select(u=> u.Editor).ToList();
            var editorsOutput = new List<SimpleUserListingModel>();
            
            editors.ForEach(e => editorsOutput.Add(new SimpleUserListingModel() { FirstName = e!.FirstName, LastName = e.LastName }));

            return Task.Run(() => editorsOutput);
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
