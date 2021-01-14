﻿namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Articles.Queries.Category;
    using Domain.Models.Articles;
    using Microsoft.EntityFrameworkCore;
    using SportBox7.Application.Features.Articles;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Articles.Queries.HomePage;
    using SportBox7.Application.Features.Articles.Queries.Id;

    internal class ArticleRepository : DataRepository<Article>, IArticleRepository
    {
        public ArticleRepository(SportBox7DbContext db)
            : base(db)
        {
        }

        public async Task<IEnumerable<ArticleByCategoryListingModel>> GetArticleListingsByCategory(
            string? category = default,
            CancellationToken cancellationToken = default)
        {
            var query = this.All();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query
                    .Where(a => a.Category.CategoryNameEN == category)
                    .OrderBy(a => a.CreationDate);
            }

            return await query
                .Select(art => new ArticleByCategoryListingModel(
                    art.Id,
                    art.Title,
                    art.Body,
                    art.ImageUrl,
                    art.Category.CategoryNameEN,
                    art.SeoUrl))
                .ToListAsync(cancellationToken);
        }

        public async Task<FrontPageOutputModel> GetArticlesForHomePage(CancellationToken cancellationToken = default)
            => await FrontPageOutputModel.CreateAsync(this);

        public async Task<ArticleByIdOutputModel> GetArticlePage(CancellationToken cancellationToken = default, int id = default)
            => await ArticleByIdOutputModel.CreateAsync(this, id);

        public List<SideBarModel> GetsideBarNews()
        {

            List<SideBarModel> model = new List<SideBarModel>();
            foreach (Category category in this.db.Categories.ToList())
            {
                model.Add(this.All().Include(c=> c.Category).Where(a => a.Category.CategoryNameEN == category.CategoryNameEN).OrderByDescending(a => a.CreationDate).Select(a => new SideBarModel(a.Id, a.Title, a.Category.CategoryNameEN, a.Category.CategoryName, a.SeoUrl, a.ImageUrl)).FirstOrDefault());
            }
            return model;
        }

        public async Task<ArticleByIdModel> GetArticleById(int id)
        {
            return await this.All().Where(a => a.Id == id).Select(a=> new ArticleByIdModel(a.Id, a.Title, a.Body, a.ImageUrl, a.Category.CategoryName, a.SeoUrl, a.MetaDescription, a.MetaKeywords, a.Title)).FirstOrDefaultAsync();
        }

        public async Task<List<LatestNewsModel>> GetLatestNews()
            => await this.All()
            .OrderByDescending(a => a.CreationDate)
            .Take(100).OrderByDescending(a => a.CreationDate)
            .Select(a =>
            new LatestNewsModel(a.Id, a.Category.CategoryNameEN, a.Title))
            .ToListAsync();
        
        public async Task<List<TopNewsModel>> GetTopNews()
            => await this.All()
            .OrderByDescending(x => x.CreationDate)
            .Take(5)
            .Select(a => new TopNewsModel(a.Id, a.Title, a.Category.CategoryNameEN, a.Category.CategoryName, a.SeoUrl, a.ImageUrl, a.Body))
            .ToListAsync();

        public async Task<List<MenuCategoriesModel>> GetMenuCategories()
            => await this.db.Categories.Select(x => new MenuCategoriesModel(x.CategoryName, x.CategoryNameEN)).ToListAsync();
       
        public async Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default)
            =>  await this.db
                .Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        public async Task<int> Total(CancellationToken cancellationToken = default)
            => await this
                .All()
                .CountAsync(cancellationToken);

    
    }
}
