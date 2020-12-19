using Microsoft.AspNetCore.Identity;
using SportBox7.Application.Features.Identity;
using SportBox7.Domain.Exeptions;
using SportBox7.Domain.Models.Editors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Infrastructure.Identity
{
    public class User: IdentityUser, IUser
    {
        internal User(string email)
            :base(email) => 
            this.Email = email;
       

        public Editor? Editor { get; private set; }

        public void BecomeEditor(Editor editor)
        {
            if (this.Editor != null)
            {
                throw new InvalidEditorException("This user is already an editor.");
            }
            this.Editor = editor;
        }
    }
}
