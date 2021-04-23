using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Jolia.Core.Libraries
{
    public static class Imaging
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var result = new Bitmap(width, height);

            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return result;
        }

        // TODO: GetScaledPicture
        public static Bitmap TempGetScaledPicture(Bitmap source, int maxWidth, int maxHeight, string watermarkFilePath = null)
        {
            int width, height;
            float aspectRatio = (float)source.Width / (float)source.Height;

            if ((maxHeight > 0) && (maxWidth > 0))
            {
                if ((source.Width < maxWidth) && (source.Height < maxHeight))
                {
                    width = source.Width;
                    height = source.Height;
                    //Return unchanged image
                    //return source;
                }
                else if (aspectRatio > 1)
                {
                    // Calculated width and height,
                    // and recalcuate if the height exceeds maxHeight
                    width = maxWidth;
                    height = (int)(width / aspectRatio);
                    if (height > maxHeight)
                    {
                        height = maxHeight;
                        width = (int)(height * aspectRatio);
                    }
                }
                else
                {
                    // Calculated width and height,
                    // and recalcuate if the width exceeds maxWidth
                    height = maxHeight;
                    width = (int)(height * aspectRatio);
                    if (width > maxWidth)
                    {
                        width = maxWidth;
                        height = (int)(width / aspectRatio);
                    }
                }
            }
            else if ((maxHeight == 0) && (source.Width > maxWidth))
            {
                // If MaxHeight is not provided (unlimited), and
                // the source width exceeds maxWidth,
                // then recalculate height
                width = maxWidth;
                height = (int)(width / aspectRatio);
            }
            else if ((maxWidth == 0) && (source.Height > maxHeight))
            {
                // If MaxWidth is not provided (unlimited), and the
                // source height exceeds maxHeight, then
                // recalculate width
                height = maxHeight;
                width = (int)(height * aspectRatio);
            }
            else
            {
                width = source.Width;
                height = source.Height;
            }

            if (watermarkFilePath != null)
            {
                Bitmap newImage = GetSmallSizeCopy(source, width, height, LowResolution: true);
                newImage = AddWaterMark(source, watermarkFilePath);
                return newImage;
            }
            else
            {
                return source;
            }
        }

        public static Bitmap GetSmallSizeCopy(Image image, int width, int height, bool LowResolution)
        {
            Bitmap result = new Bitmap(width, height);

            if (LowResolution)
            {
                result.SetResolution(72, 72);
            }
            else
            {
                result.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            }
            
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.Default;
                graphics.InterpolationMode = InterpolationMode.Low;
                graphics.SmoothingMode = SmoothingMode.Default;
                graphics.PixelOffsetMode = PixelOffsetMode.Default;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return result;
        }

        public static Bitmap AddWaterMark(Bitmap image, string watermarkFilePath)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Image watermarkImage = Bitmap.FromFile(watermarkFilePath))
            using (Graphics graphics = Graphics.FromImage(result))
            using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.Default;
                graphics.InterpolationMode = InterpolationMode.Low;
                graphics.SmoothingMode = SmoothingMode.Default;
                graphics.PixelOffsetMode = PixelOffsetMode.Default;

                graphics.DrawImage(image, 0, 0, image.Width, image.Height);

                var w = image.Width / 5;
                var h = watermarkImage.Height * w / watermarkImage.Width;
                int x = image.Width - w - 5;
                int y = image.Height - h - 5;

                graphics.DrawImage(watermarkImage, x, y, w, h);

                return result;
            }
        }
    }
}
