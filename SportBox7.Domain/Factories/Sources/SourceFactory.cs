using SportBox7.Domain.Exeptions;
using SportBox7.Domain.Models.Sources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportBox7.Domain.Factories.Sources
{
    public class SourceFactory : ISourceFactory
    {
        private string sourceUrl = default!;
        private string sourceName = default!;
        private string sourceImageUrl = default!;
        private bool isSourceUrlSet = false;
        private bool isSourceNameSet = false;
        private bool isSourceImageUrlSet = false;

        public ISourceFactory WithSourceUrl(string sourceUrl)
        {
            this.sourceUrl = sourceUrl;
            this.isSourceUrlSet = true;
            return this;
        }

        public ISourceFactory WithSourceName(string sourceName)
        {
            this.sourceName = sourceName;
            this.isSourceNameSet = true;
            return this;
        }

        public ISourceFactory WithSourceImageUrl(string sourceImageUrl)
        {
            this.sourceImageUrl = sourceImageUrl;
            this.isSourceImageUrlSet = true;
            return this;
        }

        public Source Build()
        {
            if (this.isSourceImageUrlSet == false || this.isSourceNameSet == false || isSourceUrlSet == false)
            {
                throw new InvalidSourceException("SourceImageUrl, SourceName and SourceUrl must have value");
            }
            return new Source(sourceName, sourceUrl, sourceImageUrl);
        }

        public Task<Source> BuildAsync()
        {
            if (this.isSourceImageUrlSet == false || this.isSourceNameSet == false || isSourceUrlSet == false)
            {
                throw new InvalidSourceException("SourceImageUrl, SourceName and SourceUrl must have value");
            }
            return Task.Run(()=> new Source(sourceName, sourceUrl, sourceImageUrl));
        }
    }
}
