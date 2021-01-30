using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SportBox7.Application.Common;
using SportBox7.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBox7.Web
{
    public abstract class MainController: Controller
    {
        private IMediator? mediator;

        protected IMediator Mediator =>
            this.mediator ??= this.HttpContext
            .RequestServices
            .GetRequiredService<IMediator>();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult> Send(IRequest<Result> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
            => this.Mediator.Send(request).ToActionResult();
    }
}
