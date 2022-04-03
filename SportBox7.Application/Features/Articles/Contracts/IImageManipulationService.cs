namespace SportBox7.Application.Features.Articles.Contracts
{
    public interface IImageManipulationService
    {
        public byte[] ResizeImageStaticProportions(byte[] fileContents,
            int maxWidth);
    }
}
