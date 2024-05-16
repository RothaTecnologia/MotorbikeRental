using MotorbikeRental.Domain.Interfaces.Images;
using System.Drawing;
using System.Drawing.Imaging;

namespace MotorbikeRental.Infrastructure.Images
{
    public class ImageTransform : IImageTransform
    {
        public ImageTransform() { }

        private byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public void saveCNHImage(byte[] bytesImage, Guid deliverymanID) 
        {
            var image = byteArrayToImage(bytesImage);
            string strImageName = string.Empty;
            string path = "~/ReposImages/CNH/";


            using (var im = Image.FromStream(new MemoryStream(bytesImage)))
            {
                var frmt = new ImageFormat(deliverymanID);
                if (ImageFormat.Png.Equals(im.RawFormat))
                {
                    strImageName = $"{deliverymanID}.png";

                    frmt = ImageFormat.Png;
                }

                string fullPath = $"{path}{strImageName}";
                im.Save(path, frmt);
            }
        }
    }
}
