namespace SportBox7.Domain.Models.Sources
{
    using SportBox7.Domain.Common;
    using SportBox7.Domain.Exeptions;
    using static SportBox7.Domain.Models.ModelConstants.Source;

    public class Source: Entity<int>, IAggregateRoot
    {
        internal Source(string sourceName, string sourceUrl, string sourceImageUrl)
        {
            this.Validate(sourceName, sourceUrl, sourceImageUrl);
            this.SourceName = sourceName;
            this.SourceUrl = sourceUrl;
            this.SourceImageUrl = sourceImageUrl;
        }

        private void Validate(string sourceName, string sourceUrl, string sourceImageUrl)
        {
            this.ValidateSourceName(sourceName);
            this.ValidateSourceUrl(sourceUrl);
            this.ValidateSourceImageUrl(sourceImageUrl);
        }

        public Source UpdateSourceImageUrl(string imageUrl)
        {
            this.ValidateSourceImageUrl(imageUrl);
            this.SourceImageUrl = imageUrl;
            return this;
        }

        public Source UpdateSourceUrl(string sourceUrl)
        {
            this.ValidateSourceUrl(sourceUrl);
            this.SourceUrl = sourceUrl;

            return this;
        }

        public Source UpdateSourceName(string sourceName)
        {
            this.ValidateSourceName(sourceName);
            this.SourceName = sourceName;

            return this;
        }

        public Source UpdateImageUrl(string imageUrl)
        {
            this.ValidateSourceImageUrl(imageUrl);
            this.SourceImageUrl = imageUrl;

            return this;
        }


        private void ValidateSourceImageUrl(string sourceImageUrl)
        {
            Validator.CheckForEmptyString<InvalidSourceException>(sourceImageUrl, "sourceName");
            Validator.CheckValidUrl<InvalidSourceException>(sourceImageUrl);
        }

        private void ValidateSourceUrl(string sourceUrl)
        {
            Validator.CheckForEmptyString<InvalidSourceException>(sourceUrl, "sourceName");
            Validator.CheckValidUrl<InvalidSourceException>(sourceUrl);
        }

        private void ValidateSourceName(string sourceName)
        {
            Validator.CheckForEmptyString<InvalidSourceException>(sourceName, "sourceName");
            Validator.CheckStringLength<InvalidSourceException>(sourceName, SourceNameMinLength, SourceNameMaxLength, "sourceName");
        }

        public string SourceUrl { get; private set; } = default!;

        public string SourceName { get; private set; } = default!;

        public string SourceImageUrl { get; private set; } = default!;
    }
}
