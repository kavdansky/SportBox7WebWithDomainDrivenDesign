﻿namespace SportBox7.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Application.Features.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using SportBox7.Application.Common;
    using SportBox7.Application.Exceptions;
    using SportBox7.Application.Features.Identity.Commands.CreateUser;
    using SportBox7.Application.Features.Identity.Commands.EditUser;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using SportBox7.Application.Features.Identity.Commands.LogoutUser;
    using SportBox7.Application.Features.Identity.Queries.AllUsers;
    using SportBox7.Application.Features.Identity.Queries.EditUser;
    using SportBox7.Application.Features.Identity.Queries.LoginUser;
    using SportBox7.Application.Features.Identity.Queries.RegisterUser;
    using SportBox7.Application.Features.Identity.Queries.UserDetails;
    using SportBox7.Domain.Models.Editors;
    using SportBox7.Infrastructure.Identity;

    public class IdentityController : MainController
    {
        private readonly IIdentity identityService;

        public IdentityController(IIdentity identityService)
        {
            this.identityService = identityService;
        }

        [Route("identity/details")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDetailsOutputModel>> Details([FromQuery] UserDetailsQuery query)
            => View(await this.Mediator.Send(query));

        [Route("identity/editors")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ListUsersOutputModel>> Index([FromQuery] ListUsersQuery query)
            => View(await this.Mediator.Send(query));

        [HttpGet]
        [Route("identity/login")]
        public async Task<ActionResult<LoginUserInputModel>> Login(string? errorMessage)
            => View(await LoginUserInputModel.CreateAsync(errorMessage));

        [HttpPost]
        [Route("identity/login")]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
        {
            var result = await this.Mediator.Send(command);
            if (!result.Succeeded)
            {
                return RedirectToAction("Login", new { errorMessage = string.Join(", ", result.Errors) });
            }
            return RedirectToAction("Index", "Editors", result.Data ?? new LoginOutputModel("", 0, ""));
        }

        [Authorize]
        [HttpGet]
        [Route("identity/logout")]
        public async Task<ActionResult> Logout(LogoutUserCommand command)
        {
            await this.Mediator.Send(command);
            return RedirectToAction("Login");
        }

        [Route("identity/edit")]
        public async Task<ActionResult<EditUserInputModel>> Edit(EditUserQuery query)
        {
            try
            {
                var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (User.IsInRole("Admin") || identityService.CheckPermitForEdit(loggedUserId, query.Id))
                {
                    var result = await this.Mediator.Send(query);
                    return View(result);
                }
                return Redirect("/Home/NotFound");
            }
            catch (Exception)
            {
                return Redirect("/Home/NotFound");
            }
        }
          
        [HttpPost]
        [Route("identity/edit")]
        public async Task<ActionResult<EditUserOutputModel>> Edit(EditUserCommand command)
        {
            try
            {
                var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (User.IsInRole("Admin") || identityService.CheckPermitForEdit(loggedUserId, command.Id))
                {
                    var result = await this.Mediator.Send(command);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit", new EditUserQuery { Id = command.Id });
            }
            catch (ModelValidationException ex)
            {
                return RedirectToAction("Edit", new EditUserQuery {Errors = ex.Errors, Id = command.Id });
            }
            
        }

        [Route("identity/register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RegisterUserInputModel>> Register(RegisterUserQuery query)
          => View(await this.Mediator.Send(query));

        [HttpPost]
        [Route("identity/register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CreateUserOutputModel>> Register(
            CreateUserCommand command)
        {
            try
            {
                var result = await this.Mediator.Send(command);
                if (result.Errors.Count > 0)
                {
                    return RedirectToAction("Register", await RegisterUserInputModel.CreateAsync(result.Errors));
                }
                return Redirect("identity/editors");
            }
            catch (ModelValidationException ex)
            {
                return RedirectToAction("Register", await RegisterUserInputModel.CreateAsync(ex.Errors));
            }
            
        }
    }
}
