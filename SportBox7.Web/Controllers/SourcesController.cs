
namespace SportBox7.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Features.Sources.Commands.Create;
    using SportBox7.Application.Features.Sources.Queries.Create;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SourcesController: MainController
    {
        [Route("/sources/createSource")]
        [HttpGet]
        public async Task<ActionResult<CreateSourceInputModel>> CreateSource(string? errorMessage)
       => View(await CreateSourceInputModel.CreateAsync(errorMessage));


        [Route("/sources/createSource")]
        [HttpPost]
        public async Task<ActionResult<CreateSourceOutputModel>> CreateSource(CreateSourceCommand command)
       => await this.Mediator.Send(command);
    }
}
