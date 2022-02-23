namespace SportBox7.Application.Features.Articles.Contracts
{
    public interface IImageManipulatioнService
    {
        public byte[] ResizeImageStaticProportions(byte[] fileContents,
            int maxWidth);
    }
}
