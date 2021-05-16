
namespace SportBox7.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Features.Sources.Commands.Create;
    using SportBox7.Application.Features.Sources.Commands.Edit;
    using SportBox7.Application.Features.Sources.Queries.Details;
    using SportBox7.Application.Features.Sources.Queries.Create;
    using SportBox7.Application.Features.Sources.Queries.Edit;
    using SportBox7.Application.Features.Sources.Queries.Index;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class SourcesController: MainController
    {
        [Route("/sources/createSource")]
        [HttpGet]
        public async Task<ActionResult<CreateSourceInputModel>> CreateSource(string? errorMessage)
       => View(await CreateSourceInputModel.CreateAsync(errorMessage));


        [Route("/sources/createSource")]
        [HttpPost]
        public async Task<ActionResult<CreateSourceOutputModel>> CreateSource(CreateSourceCommand command)
        { 
            var result = await this.Mediator.Send(command);

            if (!result.Succeeded)
            {
                return await Task.Run(() => View(CreateSourceInputModel.CreateAsync(string.Join(", ", result.Errors))));
            }
            return RedirectToAction("Index");
        }

        [Route("/sources/details")]
        public async Task<ActionResult<SourceByIdOutputModel>> Details(SourceByIdQuery query)
            => View(await this.Mediator.Send(query));

        [Route("/sources")]
        public async Task<ActionResult<SourcesOutputModel>> Index(ListSourcesQuery query)
            => View(await this.Mediator.Send(query));
 
        [Route("/sources/edit")]
        public async Task<ActionResult<EditSourceOutputModel>> Edit(EditSourceQuery query)
            => View(await this.Mediator.Send(query));

        [Route("/sources/edit")]
        [HttpPost]
        public async Task<ActionResult<EditedSourceOutputModel>> Edit(EditSourceCommand command)
        {
            await this.Mediator.Send(command);
            return RedirectToAction("Index");
        }
            

    }
}
