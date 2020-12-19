using SportBox7.Domain.Models.Editors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Factories.Editors
{
    public interface IEditorFactory: IFactory<Editor>
    {
        IEditorFactory WithFirstName(string firstName);

        IEditorFactory WithLastName(string lastName);

    }
}
