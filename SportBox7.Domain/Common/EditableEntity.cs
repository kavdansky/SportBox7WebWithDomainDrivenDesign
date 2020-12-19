using SportBox7.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Common
{
    public abstract class EditableEntity<TId> : Entity<TId>, IEditableEntity
        where TId : struct
    {
        public DateTime CreationDate { get; set; }

        public DateTime LastModDate { get; set; }      
    }
}
