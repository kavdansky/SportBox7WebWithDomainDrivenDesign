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

        public async Task<EditSourceOutputModel> GetSourceToEditById(int id)
            => await this.mapper.ProjectTo<EditSourceOutputModel>(getSourceById(id)).FirstOrDefaultAsync();

        public async Task<SourceByIdOutputModel> GetSourceById(int id)
        => await this.mapper.ProjectTo<SourceByIdOutputModel>(getSourceById(id)).FirstOrDefaultAsync();

        private IQueryable<Source> GetSource(int id)
            => this.All().Where(s => s.Id == id);

        Func<int, IQueryable<Source>> getSourceById => GetSource;
        
    }
}
