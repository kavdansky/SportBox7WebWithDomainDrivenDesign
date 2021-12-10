namespace SportBox7.Application.Features.Identity.Queries.EditUser
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Identity.Common;
    using SportBox7.Domain.Models.Editors;

    public class EditUserInputModel : UserInputModel, IMetaTagable
    {
        public EditUserInputModel()
        {

        }
        public string MetaDescription => "Редактиране на потребител";

        public string MetaKeywords => "Редактиране на потребител";

        public string MetaTitle => "Редактиране на потребител";

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Editor, EditUserInputModel>().
            IncludeBase<Editor, UserInputModel>();
    }
}
