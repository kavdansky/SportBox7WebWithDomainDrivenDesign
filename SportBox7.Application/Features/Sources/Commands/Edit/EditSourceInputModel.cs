namespace SportBox7.Application.Features.Sources.Commands.Edit
{
    using SportBox7.Application.Features.Sources.Queries.Create;

    public class EditSourceInputModel: CreateSourceInputModel
    {
        public int Id { get; set; }
    }
}
