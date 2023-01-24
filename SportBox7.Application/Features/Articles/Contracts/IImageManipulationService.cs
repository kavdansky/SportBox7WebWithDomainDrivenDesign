namespace SportBox7.Application.Features.Articles.Contracts
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    public interface IImageManipulationService
    {
        public byte[] ResizeImageStaticProportions(byte[] fileContents,
            int maxWidth);

        string SaveImageFile(IFormFile image, IHostingEnvironment hostingEnvironment);
    }
}
