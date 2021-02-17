namespace SportBox7.Domain.Factories.Editors
{
    using SportBox7.Domain.Exeptions;
    using SportBox7.Domain.Models.Editors;

    internal class EditorFactory : IEditorFactory
    {
        private string firstName = default!;
        private string lastName = default!;

        private bool isFirstNameSet;
        private bool isLastNameSet;

        
        public IEditorFactory WithFirstName(string firstName)
        {
            isFirstNameSet = true;
            this.firstName = firstName;

            return this;
        }

        public IEditorFactory WithLastName(string lastName)
        {
            this.isLastNameSet = true;
            this.lastName = lastName;

            return this;
        }

        public Editor Build()
        {
            if (isFirstNameSet == false || !isLastNameSet == false)
            {
                throw new InvalidEditorException("Editor must have first and last name");
            }
            return new Editor(this.firstName, this.lastName);
        }

    }
}
