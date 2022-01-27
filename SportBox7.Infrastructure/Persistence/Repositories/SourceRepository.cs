namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using SportBox7.Domain.Models.Sources;
    using System.Collections.Generic;   
    using SportBox7.Application.Features.Sources;
    using AutoMapper;
    using System.Threading.Tasks;
    using System.Linq;
    using SportBox7.Application.Features.Sources.Queries.Edit;
    using Microsoft.EntityFrameworkCore;
    using SportBox7.Application.Features.Sources.Commands.Edit;
    using SportBox7.Application.Features.Sources.Queries.Index;
    using System;
    using SportBox7.Application.Features.Sources.Queries.Details;
    using SportBox7.Application.Features.Sources.Queries.Delete;

    internal class SourceRepository : DataRepository<Source>, ISourceRepository
    {
        private readonly IMapper mapper;

        public SourceRepository(SportBox7DbContext db, IMapper mapper)
            :base(db)
        {
            this.mapper = mapper;
        }

        public async Task<EditedSourceOutputModel> EditSource(EditSourceCommand source)
        {
            Source sourceToEdit = getSourceById(source.Id).FirstOrDefault();
            sourceToEdit.UpdateSourceName(source.SourceName);
            sourceToEdit.UpdateSourceUrl(source.SourceUrl);
            sourceToEdit.UpdateSourceImageUrl(source.SourceImageUrl);
            await this.db.SaveChangesAsync();
            return new EditedSourceOutputModel(source.Id, source.SourceName);
        }

        public async Task<IEnumerable<IndexSourceModel>> GetAllSources()
            => await Task.Run(()=> this.All().Select(x => new IndexSourceModel(x.Id, x.SourceName, x.SourceUrl, x.SourceImageUrl)).ToList());

        public Task<EditSourceOutputModel> GetSourceToEditById(int id)
            => this.mapper.ProjectTo<EditSourceOutputModel>(getSourceById(id)).FirstOrDefaultAsync();

        public Task<SourceByIdOutputModel> GetSourceById(int id)
        => this.mapper.ProjectTo<SourceByIdOutputModel>(getSourceById(id)).FirstOrDefaultAsync();

        public IQueryable<Source> GetSource(int id)
            => this.All().Where(s => s.Id == id);

        public Task<DeleteSourceOutputModel> GetSourceToDeleteById(int id)
            => this.mapper.ProjectTo<DeleteSourceOutputModel>(getSourceById(id)).FirstOrDefaultAsync();

        public async Task<IEnumerable<Source>> GetSources()
            => await base.All().ToListAsync();

        public async Task<Source> GetSourceByName(string name)
        {
            return await this.All().Where(s => s.SourceName == name).FirstOrDefaultAsync();
        }

#pragma warning disable IDE1006 // Naming Styles
        Func<int, IQueryable<Source>> getSourceById => GetSource;
#pragma warning restore IDE1006 // Naming Styles

    }
}
