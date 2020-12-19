using FluentAssertions;
using SportBox7.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SportBox7.Domain.Factories.Editors
{
    public class EditorFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfFirstNameIsNotSet()
        {
            // Assert
            var editorFactory = new EditorFactory();

            // Act
            Action act = () => editorFactory
                .WithLastName("Ivanov")
                .Build();

            // Assert
            act.Should().Throw<InvalidEditorException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfLastNameIsNotSet()
        {
            // Assert
            var editorFactory = new EditorFactory();

            // Act
            Action act = () => editorFactory
                .WithFirstName("Petar")
                .Build();

            // Assert
            act.Should().Throw<InvalidEditorException>();
        }

    }
}
