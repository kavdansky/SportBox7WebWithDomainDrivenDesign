using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Contracts
{
    public interface IMetaTagable
    {
        string MetaDescription { get; }

        string MetaKeywords { get; }

        string MetaTitle { get; }
    }
}
