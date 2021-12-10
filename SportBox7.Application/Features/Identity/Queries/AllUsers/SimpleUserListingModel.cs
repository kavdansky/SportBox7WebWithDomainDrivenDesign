﻿namespace SportBox7.Application.Features.Identity.Queries.AllUsers
{
    using AutoMapper;
    using SportBox7.Application.Mapping;
    using SportBox7.Domain.Models.Editors;

    public class SimpleUserListingModel: IMapFrom<Editor>
    {
        public int EditorId { get; set; }

        public string UserId { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public void Mapping(Profile mapper)
            => mapper.CreateMap<Editor, SimpleUserListingModel>();
    }
}
