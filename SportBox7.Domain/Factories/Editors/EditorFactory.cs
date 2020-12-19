using SportBox7.Domain.Exeptions;
using SportBox7.Domain.Models.Editors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Factories.Editors
{
    internal class EditorFactory : IEditorFactory
    {
        private string firstName = default!;
        private string lastName = default!;

        
        public IEditorFactory WithFirstName(string firstName)
        {
            this.firstName = firstName;

            return this;
        }

        public IEditorFactory WithLastName(string lastName)
        {
            this.lastName = lastName;

            return this;
        }

        public Editor Build()
        {
            return new Editor(this.firstName, this.lastName);
        }

    }
}
