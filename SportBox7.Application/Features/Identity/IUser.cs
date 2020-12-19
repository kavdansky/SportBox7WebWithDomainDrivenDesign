namespace SportBox7.Application.Features.Identity
{
    using Domain.Models.Editors;

    public interface IUser
    {
        void BecomeEditor(Editor dealer);
    }
}
