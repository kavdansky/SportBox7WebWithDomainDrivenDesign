using SportBox7.Domain.Models.Articles;
using SportBox7.Domain.Models.Sources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Factories.Sources
{
    public interface ISourceFactory: IFactory<Source>
    {
        ISourceFactory WithSourceName(string sourceName);
        ISourceFactory WithSourceImageUrl(string sourceImageUrl);
        ISourceFactory WithSourceUrl(string sourceUrl);
    }
}
