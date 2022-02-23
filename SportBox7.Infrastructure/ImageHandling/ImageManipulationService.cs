namespace SportBox7.Infrastructure.ImageHandling
{
    using SkiaSharp;
    using SportBox7.Application.Features.Articles.Contracts;
    using System;
    using System.IO;

    public class ImageManipulationService: IImageManipulatioнService
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
    }
}
