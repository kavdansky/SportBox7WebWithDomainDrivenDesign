namespace SportBox7.Infrastructure.ImageHandling
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using SkiaSharp;
    using SportBox7.Application.Features.Articles.Contracts;
    using System;
    using System.IO;

    public class ImageManipulationService: IImageManipulationService
    {
        public byte[] ResizeImageStaticProportions(byte[] fileContents,
            int maxWidth)
        {
            SKFilterQuality quality = SKFilterQuality.Medium;
            using MemoryStream ms = new MemoryStream(fileContents);
            using SKBitmap sourceBitmap = SKBitmap.Decode(ms);
            double heightWidthRatio = (double)sourceBitmap.Height / sourceBitmap.Width;
            int height = (int)Math.Min(maxWidth * heightWidthRatio, sourceBitmap.Height);
            int width = Math.Min(maxWidth, sourceBitmap.Width);
            using SKBitmap scaledBitmap = sourceBitmap.Resize(new SKImageInfo(width, height), quality);
            using SKImage scaledImage = SKImage.FromBitmap(scaledBitmap);
            using SKData data = scaledImage.Encode();

            return data.ToArray();
        }

        [Obsolete]
        public string SaveImageFile(IFormFile image, IHostingEnvironment hostingEnvironment)
        {
            var imageName = Guid.NewGuid() + ".jpg";
            string imageUrl = @$"/Images/{imageName}";
            var imageLocation = hostingEnvironment.ContentRootPath.Replace("Startup", "Web") + "/wwwroot/Images";
            using (var fileStream = new FileStream(Path.Combine(imageLocation, imageName), FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            byte[] myBinaryImage = File.ReadAllBytes(Path.Combine(imageLocation, imageName));
            var resizedImage = ResizeImageStaticProportions(myBinaryImage, 460);
            File.WriteAllBytes(Path.Combine(imageLocation, imageName), resizedImage);
            return imageUrl;
        }
    }
}
