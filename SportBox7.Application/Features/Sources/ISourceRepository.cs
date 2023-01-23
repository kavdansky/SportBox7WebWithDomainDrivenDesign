namespace SportBox7.Application.Features.Sources
{
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Sources.Commands.Edit;
    using SportBox7.Application.Features.Sources.Queries.Delete;
    using SportBox7.Application.Features.Sources.Queries.Details;
    using SportBox7.Application.Features.Sources.Queries.Edit;
    using SportBox7.Application.Features.Sources.Queries.Index;
    using SportBox7.Domain.Models.Sources;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ISourceRepository: IRepository<Source>
    {
        Task<EditedSourceOutputModel> EditSource(EditSourceCommand source);
        Task<IEnumerable<IndexSourceModel>> GetAllSources();
        Task<EditSourceOutputModel> GetSourceToEditById(int id);
        Task<SourceByIdOutputModel> GetSourceById(int id);
        Task<DeleteSourceOutputModel> GetSourceToDeleteById(int id);
        IQueryable<Source> GetSource(int id);
        Task<IEnumerable<Source>> GetSources();
        Task<IPaginatedList<IndexSourceModel>> GetPaginatedSources(int? index);
        Task<Source> GetSourceByName(string name);
    }
}
