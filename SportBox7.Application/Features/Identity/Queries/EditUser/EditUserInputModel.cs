namespace SportBox7.Application.Features.Identity.Queries.EditUser
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Application.Features.Identity.Common;
    using SportBox7.Domain.Models.Editors;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EditUserInputModel : UserInputModel, IEditorPage, IMetaTagable
    {
        public EditUserInputModel()
        {
            this.ErrorMessage = new List<string>();
        }
        public new List<string> ErrorMessage { get; set; }

        public string MetaDescription => "Редактиране на потребител";

        public string MetaKeywords => "Редактиране на потребител";

        public string MetaTitle => "Редактиране на потребител";

        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Editor, EditUserInputModel>().
            IncludeBase<Editor, UserInputModel>();
    }
}
