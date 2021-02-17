namespace SportBox7.Domain.Factories.Editors
{
    using SportBox7.Domain.Models.Editors;

    public interface IEditorFactory: IFactory<Editor>
    {
        IEditorFactory WithFirstName(string firstName);

        IEditorFactory WithLastName(string lastName);

    }
}
